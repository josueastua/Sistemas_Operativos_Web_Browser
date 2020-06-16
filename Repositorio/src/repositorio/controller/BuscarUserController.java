/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXButton;
import com.jfoenix.controls.JFXTextField;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.TableView;
import javafx.scene.input.MouseEvent;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class BuscarUserController implements Initializable {

    @FXML
    private JFXTextField txtNombre;
    @FXML
    private JFXButton btnBuscar;
    @FXML
    private TableView<?> tvUser;
    @FXML
    private JFXButton btnSeleccionar;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void accionBuscar(ActionEvent event) {
    }

    @FXML
    private void accionTabla(MouseEvent event) {
    }

    @FXML
    private void accionSeleccionar(ActionEvent event) {
    }
    
}
