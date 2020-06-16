/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
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

    @FXML
    private void accionBorrar(MouseEvent event) {
    }

    @Override
    public void initialize() {
        UsuariosDto user = (UsuariosDto) AppContext.getInstance().get("User");
        user.setVersiones();
    }
    
}
