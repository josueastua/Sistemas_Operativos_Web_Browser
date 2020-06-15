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
import repositorio.modelo.UsuariosDto;
import repositorio.service.UsuariosService;
import repositorio.util.FlowController;
import repositorio.util.Mensaje;
import repositorio.util.Respuesta;

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
    @FXML private JFXTextField txtUnserName;
    @FXML private JFXTextField txtPass;
    @FXML private JFXTextField txtPass2;
    private String mensaje;
    private Mensaje men;
    private UsuariosService service;
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        men = new Mensaje();
        service = new UsuariosService();
    }    

    @Override
    public void initialize() {
    }

    private Boolean validarRequeridos(){
        mensaje = "";
        if(txtUnserName.getText() == null || txtUnserName.getText().isEmpty()){
            mensaje += "Debe ingresar un nombre de usuario\n";
        }
        if(txtPass.getText() == null || txtPass.getText().isEmpty()){
            mensaje += "Debe ingresar una contraseña\n";
        }
        if(txtPass2.getText() == null || txtPass2.getText().isEmpty()){
            mensaje += "Debe confirmar la contraseña\n";
        }
        if(txtPass.getText() != null && !txtPass.getText().isEmpty() && txtPass2.getText() != null && !txtPass2.getText().isEmpty()){
            if(!txtPass.getText().equals(txtPass2.getText()))
                mensaje += "Las contraseñas no coinciden\n";
        }
        return mensaje.equals("");
    }
    
    @FXML
    private void accionAceptar(ActionEvent event) {
        if(validarRequeridos()){
            File carpeta = new File("C:\\raiz\\"+txtUnserName.getText()), temp = new File("C:\\raiz\\"+txtUnserName.getText()+"\\Temporal"), versions = new File("C:\\raiz\\"+txtUnserName.getText()+"\\Versiones"), permanente = new File("C:\\raiz\\"+txtUnserName.getText()+"\\Permanente");
            UsuariosDto user = new UsuariosDto(txtUnserName.getText(), txtPass.getText(), "C:\\raiz\\"+txtUnserName.getText());
            Respuesta res = service.guardarUsuario(user);
            if(res.getEstado()){
                men.show(Alert.AlertType.INFORMATION, "Registrarse", "Se registro con exito");
                if(!carpeta.exists())
                    carpeta.mkdir();
                if(!temp.exists())
                    temp.mkdir();
                if(!versions.exists())
                    versions.mkdir();
                if(!permanente.exists())
                    permanente.mkdir();
            }else{
                men.show(Alert.AlertType.ERROR, "Registrarse", res.getMensaje());
            }
        }else{
            men.show(Alert.AlertType.ERROR, "Campos Requeridos", mensaje);
        }
    }

    @FXML
    private void accionCancelar(ActionEvent event) {
        FlowController.getInstance().goViewInNoResizableWindow("Login", Boolean.TRUE);
        this.getStage().close();
    }
    
}
