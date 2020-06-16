/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXButton;
import com.jfoenix.controls.JFXTextField;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import repositorio.modelo.UsuariosDto;
import repositorio.service.UsuariosService;
import repositorio.util.AppContext;
import repositorio.util.Respuesta;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class BuscarUserController extends Controller implements Initializable {

    @FXML
    private JFXTextField txtNombre;
    @FXML
    private JFXButton btnBuscar;
    @FXML
    private TableView<UsuariosDto> tvUser;
    @FXML
    private JFXButton btnSeleccionar;
    @FXML
    private TableColumn<UsuariosDto, Integer> colId;
    @FXML
    private TableColumn<UsuariosDto, String> colNombre;
    UsuariosService service = new UsuariosService();

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
    private void initable(){
        colId.setCellValueFactory(new PropertyValueFactory("usuId"));
        colNombre.setCellValueFactory(new PropertyValueFactory("usuNombre"));
    }

    @FXML
    private void accionBuscar(ActionEvent event) {
        String nombre = txtNombre.getText().isEmpty() ? "%" : "%"+txtNombre.getText()+"%";
        Respuesta res = service.getUsuariosByName(nombre);
        if(res.getEstado()){
              tvUser.getItems().clear();
              tvUser.getItems().addAll((List<UsuariosDto>) res.getResultado("Usuarios"));
        }
    }


    @FXML
    private void accionSeleccionar(ActionEvent event) {
        if(tvUser.getSelectionModel().getSelectedItem() != null){
            AppContext.getInstance().set("Select", tvUser.getSelectionModel().getSelectedItem());
            this.getStage().close();
        }
    }

    @Override
    public void initialize() {
        initable();
    }
    
}
