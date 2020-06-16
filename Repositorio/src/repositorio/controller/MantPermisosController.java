/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXToggleButton;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import repositorio.modelo.PermisosDto;
import repositorio.modelo.UsuariosDto;
import repositorio.util.AppContext;
import repositorio.util.FlowController;
import repositorio.util.Mensaje;
import repositorio.service.PermisosServices;
import repositorio.util.Respuesta;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class MantPermisosController extends Controller implements Initializable {

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
    PermisosDto newPap, select;
    UsuariosDto user, userselect;
    PermisosServices service = new PermisosServices();

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        men = new Mensaje();
        men.show(Alert.AlertType.INFORMATION, "Eliminar", "Use Suprimir o Delete para eliminar");
    }    

    @FXML
    private void accionTabla(MouseEvent event) {
        if(tvPermisos.getSelectionModel().getSelectedItem() != null){
            select = tvPermisos.getSelectionModel().getSelectedItem();
            mostrarDatos();
        }
    }
    
    private void initTabla(){
        colId.setCellValueFactory(new PropertyValueFactory("perId"));
        colUserName.setCellValueFactory(new PropertyValueFactory("perUsuario"));
        colCrear.setCellValueFactory(new PropertyValueFactory("perCrear"));
        colBorrar.setCellValueFactory(new PropertyValueFactory("perBorrar"));
        colGuardar.setCellValueFactory(new PropertyValueFactory("perEditar"));
        colLeer.setCellValueFactory(new PropertyValueFactory("perLeer"));
        tvPermisos.getItems().clear();
        tvPermisos.getItems().addAll(user.getPermisosDados());
    }
    
    public void mostrarDatos(){
        lblUser.setText(select.getPerUsuario());
        tbCrear.setSelected(select.getPerCrear() == 1);
        tbBorrar.setSelected(select.getPerBorrar() == 1);
        tbGuardarEditar.setSelected(select.getPerEditar() == 1);
        tbLeer.setSelected(select.getPerLeer() == 1);
        
    }

    @FXML
    private void accion(KeyEvent event) {
        if(tvPermisos.getSelectionModel().getSelectedItem() != null){
            if(event.getCode().equals(KeyCode.DELETE)){
                if(men.showConfirmation("Eliminar Permiso", this.getStage(), "Eliminar este permiso?")){
                    PermisosDto per = tvPermisos.getSelectionModel().getSelectedItem();
                    Respuesta res = service.eliminarPermiso(per.getPerId());
                    if(res.getEstado()){
                        men.show(Alert.AlertType.INFORMATION, "Eliminar Permiso", "Permiso eliminado");
                        user.getPermisosDados().remove(per);
                    }
                }
            }
        }
    }


    @Override
    public void initialize() {
        user = (UsuariosDto) AppContext.getInstance().get("User");
        initTabla();
    }

    @FXML
    private void accionUser(MouseEvent event) {
        FlowController.getInstance().goViewInNoResizableWindow("BuscarUser", Boolean.FALSE);
        userselect = (UsuariosDto) AppContext.getInstance().get("Select");
        if(userselect != null){
            lblUser.setText(userselect.getUsuNombre());
        }
    }

    @FXML
    private void accionGuardar(ActionEvent event) {
        if(select != null){
            newPap = new PermisosDto(select.getPerId());
            newPap.setPerDueno(select.getPerDueno());
            newPap.setPerUsuario(lblUser.getText());
            newPap.setPerCrear(tbCrear.isSelected() ? 1 : 0);
            newPap.setPerBorrar(tbBorrar.isSelected() ? 1 : 0);
            newPap.setPerEditar(tbGuardarEditar.isSelected() ? 1 : 0);
            newPap.setPerLeer(tbLeer.isSelected() ? 1 : 0);
            Respuesta res = service.guardarPermiso(newPap);
            if(res.getEstado()){
                men.show(Alert.AlertType.INFORMATION, "Crear Permiso", "Permiso creado");
                user.addPermisoDados((PermisosDto) res.getResultado("Permiso"));
                tvPermisos.getItems().clear();
                tvPermisos.getItems().addAll(user.getPermisosDados());
            }
        }else{
            if(userselect != null){
                newPap = new PermisosDto(0);
                newPap.setPerDueno(user.getUsuNombre());
                newPap.setPerUsuario(userselect.getUsuNombre());
                newPap.setPerCrear(tbCrear.isSelected() ? 1 : 0);
                newPap.setPerBorrar(tbBorrar.isSelected() ? 1 : 0);
                newPap.setPerEditar(tbGuardarEditar.isSelected() ? 1 : 0);
                newPap.setPerLeer(tbLeer.isSelected() ? 1 : 0);
                Respuesta res = service.guardarPermiso(newPap);
            if(res.getEstado()){
                men.show(Alert.AlertType.INFORMATION, "Crear Permiso", "Permiso creado");
                user.addPermisoDados((PermisosDto) res.getResultado("Permiso"));
                tvPermisos.getItems().clear();
                tvPermisos.getItems().addAll(user.getPermisosOtorgados());
            }
            }else{
                men.show(Alert.AlertType.INFORMATION, "Gestinar permisos", "Faltan datos");
            }
        }
        clear();
    }
    
    public void clear(){
        lblUser.setText("");
        tbBorrar.setSelected(false);
        tbCrear.setSelected(false);
        tbGuardarEditar.setSelected(false);
        tbLeer.setSelected(false);
        select = null;
        userselect = null;
    }
    
}
