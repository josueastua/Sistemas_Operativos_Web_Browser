/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXToggleButton;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import repositorio.modelo.PermisosDto;
import repositorio.util.Mensaje;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class MantPermisosController implements Initializable {

    @FXML private TableView<PermisosDto> tvPermisos;
    @FXML private TableColumn<PermisosDto, Integer> colId;
    @FXML private TableColumn<PermisosDto, String> colUserName;
    @FXML private TableColumn<PermisosDto, Integer> colCrear;
    @FXML private TableColumn<PermisosDto, Integer> colLeer;
    @FXML private TableColumn<PermisosDto, Integer> colBorrar;
    @FXML private TableColumn<PermisosDto, Integer> colGuardar;
    @FXML private Label lblTitulo;
    @FXML private JFXToggleButton tbBorrar;
    @FXML private JFXToggleButton tbGuardarEditar;
    @FXML private JFXToggleButton tbCrear;
    @FXML private JFXToggleButton tbLeer;
    @FXML private Label lblUser;
    Mensaje men;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        men = new Mensaje();
        men.show(Alert.AlertType.INFORMATION, "Eliminar", "Use CTRL+D para eliminar");
    }    

    @FXML
    private void accionTabla(MouseEvent event) {
    }

    @FXML
    private void accion(KeyEvent event) {
    }

    @FXML
    private void accionEliminar(KeyEvent event) {
    }
    
}
