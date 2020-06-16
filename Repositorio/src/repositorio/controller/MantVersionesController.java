/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import java.net.URL;
import java.util.HashMap;
import java.util.List;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import repositorio.modelo.UsuariosDto;
import repositorio.modelo.VersionesDto;
import repositorio.util.AppContext;

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
    

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void accionTabla(MouseEvent event) {
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
            tvVersiones.getItems().addAll(visualizar.get(aux.getText()));
        }
    }
}
