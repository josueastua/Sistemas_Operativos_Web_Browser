/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import com.jfoenix.controls.JFXButton;
import com.jfoenix.controls.JFXHamburger;
import com.jfoenix.transitions.hamburger.HamburgerBackArrowBasicTransition;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class PrincipalController extends Controller implements Initializable {

    @FXML
    private BorderPane bpRoot;
    @FXML
    private HBox hbEcabezado;
    @FXML
    private Label lblTitulo;
    @FXML
    private JFXHamburger hamMenu;
    @FXML
    private VBox vbContMenu;
    @FXML
    private VBox vbMenu;
    @FXML
    private Label lblUser;
    @FXML
    private JFXButton btnCambiar;
    @FXML
    private JFXButton btnVersiones;
    @FXML
    private JFXButton btnPapelera;
    @FXML
    private JFXButton btnCerrar;
    @FXML
    private VBox vbContenedor;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void accionCambiar(ActionEvent event) {
    }

    @FXML
    private void accionVersiones(ActionEvent event) {
    }

    @FXML
    private void accionPapelera(ActionEvent event) {
    }

    @FXML
    private void accionCerrar(ActionEvent event) {
    }

    @Override
    public void initialize() {
        HamburgerBackArrowBasicTransition transition = new HamburgerBackArrowBasicTransition(hamMenu);
        transition.setRate(-1);
        hamMenu.addEventHandler(MouseEvent.MOUSE_PRESSED,(e)->{
                transition.setRate(transition.getRate()*-1);
                transition.play();
        });
    }

    @FXML
    private void accionHambueger(MouseEvent event) {
        
    }
    
}
