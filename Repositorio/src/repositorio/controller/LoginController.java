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
import java.util.List;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import repositorio.modelo.PapeleraDto;
import repositorio.modelo.PermisosDto;
import repositorio.modelo.UsuariosDto;
import repositorio.modelo.VersionesDto;
import repositorio.service.PapeleraService;
import repositorio.service.PermisosServices;
import repositorio.service.UsuariosService;
import repositorio.service.VersionesService;
import repositorio.util.AppContext;
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
        txtUsuario.setText("");
        txtPassword.setText("");
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
                UsuariosDto user = (UsuariosDto) res.getResultado("Usuario");
                listaUsuario(user);
                AppContext.getInstance().set("User", user);
                FlowController.getInstance().goViewInNoResizableWindow("Principal", Boolean.TRUE);
                this.getStage().close();
            }else{
                men.show(Alert.AlertType.WARNING, "Iniciar Sesion", res.getMensaje());
            }
        }
    }
    
    private void listaUsuario(UsuariosDto user){
        PermisosServices perservice = new PermisosServices();
        PapeleraService papservice = new PapeleraService();
        VersionesService verservice = new VersionesService();
        Respuesta res;
        res = perservice.getPermisosByUsuario(user.getUsuNombre());
        if(res.getEstado())
            user.setPermisosOtorgados((List<PermisosDto>) res.getResultado("Permisos"));
        res = perservice.getPermisosByDueno(user.getUsuNombre());
        if(res.getEstado())
            user.setPermisosDados((List<PermisosDto>) res.getResultado("Permisos"));
        res = papservice.getPapeleraByIdUsuario(user.getUsuId());
        if(res.getEstado())
            user.setPapelera((List<PapeleraDto>) res.getResultado("Papelera"));
        res = verservice.getVersionesByUsuario(user.getUsuNombre());
        if(res.getEstado())
            user.setVerlist((List<VersionesDto>) res.getResultado("Versiones"));
    }
    
}
