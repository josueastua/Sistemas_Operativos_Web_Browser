/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXButton;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.SelectionMode;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import repositorio.modelo.PapeleraDto;
import repositorio.modelo.UsuariosDto;
import repositorio.service.PapeleraService;
import repositorio.util.AppContext;
import repositorio.util.Mensaje;
import repositorio.util.Respuesta;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class PapeleraController extends Controller implements Initializable {

    @FXML
    private TableView<PapeleraDto> tvPapelera;
    @FXML
    private TableColumn<PapeleraDto, Integer> colId;
    @FXML
    private TableColumn<PapeleraDto, String> colDirAnt;
    @FXML
    private TableColumn<PapeleraDto, String> colDirAct;
    @FXML
    private Label lblTitulo;
    @FXML
    private JFXButton btnRecuperar;
    UsuariosDto user;
    PapeleraService service = new PapeleraService();
    Mensaje men = new Mensaje();

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        tvPapelera.getSelectionModel().setSelectionMode(SelectionMode.MULTIPLE);
    }  
    
    public void initTable(){
        tvPapelera.getItems().clear();
        tvPapelera.getItems().addAll(user.getPapelera());
        colId.setCellValueFactory(new PropertyValueFactory("papId"));
        colDirAnt.setCellValueFactory(new PropertyValueFactory("papDir"));
        colDirAct.setCellValueFactory(new PropertyValueFactory("papNombreArch"));
    }


    @FXML
    private void accionRecuperar(ActionEvent event) {
        if(tvPapelera.getSelectionModel().getSelectedItems() != null){
            for(PapeleraDto pap : tvPapelera.getSelectionModel().getSelectedItems()){
                try {
                    Path destino = Paths.get(pap.getPapDir()), origen;
                    File file = new File(pap.getPapNombreArch());
                    origen = Paths.get(file.getAbsolutePath());
                    Files.move(origen, destino.resolve(origen.getFileName()));
                    Respuesta res = service.eliminarPermiso(pap.getPapId());
                    if(res.getEstado())
                        System.out.println("Exito");
                    user.getPapelera().remove(pap);
                } catch (IOException ex) {
                    Logger.getLogger(PapeleraController.class.getName()).log(Level.SEVERE, null, ex);
                }
                String mensaje;
                if(tvPapelera.getSelectionModel().getSelectedItems().size() > 1){
                    mensaje = "Archivos recuperados";
                }else{
                    mensaje = "Archivo recuperado";
                }
                men.show(Alert.AlertType.INFORMATION, "Recuperar Archivos", mensaje);
            }
            this.getStage().close();
        }
    }

    @Override
    public void initialize() {
        user = (UsuariosDto) AppContext.getInstance().get("User");
        initTable();
    }
    
}
