/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXButton;
import com.jfoenix.controls.JFXTextField;
import java.io.File;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class RegistroController extends Controller implements Initializable {

    @FXML private Label lbl_Titulo;
    @FXML private ImageView imv_usu;
    @FXML private ImageView imv_pass2;
    @FXML private ImageView imv_pass;
    @FXML private JFXButton btn_aceptar;
    @FXML private JFXButton btn_Cancelar;
    @FXML private JFXTextField tf_Nombre;
    @FXML private JFXTextField tf_Apellido;
    @FXML private JFXTextField tf_Cedula;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }    

    @Override
    public void initialize() {
        File raiz = new File("C:\\raiz");
        if(!raiz.exists()){
            if(raiz.mkdirs()){
                System.out.println("Directorio creado");
            }
        }else{
            System.out.println("Ya existe el directorio");
        }
    }

    @FXML
    private void accionAceptar(ActionEvent event) {
    }

    @FXML
    private void accionCancelar(ActionEvent event) {
    }
    
}
