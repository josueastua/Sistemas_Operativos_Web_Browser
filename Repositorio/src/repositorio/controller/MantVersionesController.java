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

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class MantVersionesController implements Initializable {

    @FXML
    private TableView<?> tvVersiones;
    @FXML
    private TableColumn<?, ?> colCarpeta;
    @FXML
    private TableColumn<?, ?> colArchivo;
    @FXML
    private ListView<?> lvVersiones;
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
    
}