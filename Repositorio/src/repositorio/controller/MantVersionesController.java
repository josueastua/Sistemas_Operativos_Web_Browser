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
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import repositorio.modelo.UsuariosDto;
import repositorio.modelo.VersionesDto;
import repositorio.util.AppContext;
import repositorio.util.Mensaje;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class MantVersionesController extends Controller implements Initializable {

    @FXML
    private TableView<VersionesDto> tvVersiones;
    @FXML
    private TableColumn<VersionesDto, String> colCarpeta;
    @FXML
    private TableColumn<VersionesDto, String> colArchivo;
    @FXML
    private ListView<Label> lvVersiones;
    @FXML
    private Label lblTitulo;
    UsuariosDto user;
    HashMap<String, List<VersionesDto>> visualizar;
    List<VersionesDto> select;
    @FXML
    private JFXButton btnRecovery;
    Mensaje men;
    

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    



    @Override
    public void initialize() {
        user = (UsuariosDto) AppContext.getInstance().get("User");
        user.setVersiones();
        initTabla();
        initList();
    }
    
    public void initTabla(){
        tvVersiones.getItems().clear();
        colArchivo.setCellValueFactory(new PropertyValueFactory("verArchivo"));
        colCarpeta.setCellValueFactory(new PropertyValueFactory("verCarpeta"));
    }
    
    public void initList(){
        lvVersiones.getItems().clear();
        visualizar = user.getVersiones();
        Label aux;
        for(String key: visualizar.keySet()){
            aux = new Label(key);
            aux.setPrefSize(266, 40);
            lvVersiones.getItems().add(aux);
        }
        
    }

    @FXML
    private void accionMostrar(MouseEvent event) {
        if(lvVersiones.getSelectionModel().getSelectedItem() != null){
            Label aux = lvVersiones.getSelectionModel().getSelectedItem();
            tvVersiones.getItems().clear();
            select = visualizar.get(aux.getText());
            tvVersiones.getItems().addAll(select);
        }
    }

    @FXML
    private void accionRecuperar(ActionEvent event) {
        if(select != null){
            List<File> files = new ArrayList<>();
            File aux;
            for(VersionesDto ver : select){
                aux = new File("C:\\raiz\\"+user.getUsuNombre()+"\\Versiones\\"+ver.getVerArchivo());
                if(aux.exists()){
                    try{
                        Path destino = Paths.get("C:\\raiz\\"+user.getUsuNombre()+"\\Versiones\\"), origen;
                        origen = Paths.get(aux.getAbsolutePath());
                        Files.move(origen, destino.resolve(origen.getFileName()));
                    }catch(IOException ex){
                        System.out.println(ex);
                    }
                }
            }
            men.show(Alert.AlertType.INFORMATION, "Recuperar Version", "Version recuperada exitosamente");
        }
    }
}
