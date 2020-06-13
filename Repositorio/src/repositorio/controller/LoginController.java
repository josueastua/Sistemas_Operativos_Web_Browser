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
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;

/**
 *
 * @author IVAN
 */
public class LoginController extends Controller implements Initializable {
    
    @FXML private Label LBL_TITULO;
    @FXML private ImageView iv_usu;
    @FXML private ImageView iv_con;
    @FXML private JFXTextField tF_usuario001;
    @FXML private JFXTextField tF_password001;
    @FXML private JFXButton btn_Registrarse;
    @FXML private JFXButton btn_Acceder;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @Override
    public void initialize() {
    }

    @FXML
    private void accionRegistrarse(ActionEvent event) {
    }

    @FXML
    private void accion_Acceder(ActionEvent event) {
    }
    
}
