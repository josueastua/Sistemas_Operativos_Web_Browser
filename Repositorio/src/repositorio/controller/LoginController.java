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
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import javax.swing.filechooser.FileSystemView;
import repositorio.service.UsuariosService;
import repositorio.util.FlowController;
import repositorio.util.Mensaje;
import repositorio.util.Respuesta;

/**
 *
 * @author IVAN
 */
public class LoginController extends Controller implements Initializable {
    
    @FXML private Label LBL_TITULO;
    @FXML private ImageView iv_usu;
    @FXML private ImageView iv_con;
    @FXML private JFXButton btn_Registrarse;
    @FXML private JFXButton btn_Acceder;
    UsuariosService service;
    @FXML private JFXTextField txtUsuario;
    @FXML private JFXTextField txtPassword;
    Mensaje men;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        service = new UsuariosService();
        men = new Mensaje();
    }    

    @Override
    public void initialize() {
        File file = new File("C:\\raiz");
        if(!file.exists())
            file.mkdir();
    }

    @FXML
    private void accionRegistrarse(ActionEvent event) {
        FlowController.getInstance().goViewInNoResizableWindow("Registro", Boolean.TRUE);
        this.getStage().close();
    }

    @FXML
    private void accion_Acceder(ActionEvent event) {
        if(txtUsuario.getText() != null && !txtUsuario.getText().isEmpty() && txtPassword.getText() != null && !txtPassword.getText().isEmpty()){
            Respuesta res = service.userLogin(txtUsuario.getText(), txtPassword.getText());
            if(res.getEstado()){
                FlowController.getInstance().goViewInResizableWindow("Principal", 0, 1100, 0, 700, Boolean.TRUE);
                this.getStage().close();
            }else{
                men.show(Alert.AlertType.WARNING, "Iniciar Sesion", res.getMensaje());
            }
        }
    }
    
}
