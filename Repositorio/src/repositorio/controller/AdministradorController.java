/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;


import com.jfoenix.controls.JFXButton;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.Initializable;
import java.awt.image.BufferedImage;
import java.io.File;
import javafx.embed.swing.SwingFXUtils;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.ScrollPane;
import javafx.scene.image.Image;
import javafx.scene.layout.BorderPane;
import javax.swing.ImageIcon;
import javax.swing.filechooser.FileSystemView;



/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class AdministradorController implements Initializable {

    @FXML private BorderPane bpAdmRoot;
    @FXML private JFXButton btnBorrar;
    @FXML private JFXButton btnNuevo;
    @FXML private JFXButton btnEditar;
    @FXML private JFXButton btnAbrir;
    @FXML private JFXButton btnUpdate;
    @FXML private JFXButton btnCommit;
    @FXML private ScrollPane spContenedor;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        /*
        
        */
    } 
    
    private void cargarCarpeta(File file){
        
    }
    
    private Image convertirImage(File file){
        ImageIcon icon = (ImageIcon) FileSystemView.getFileSystemView().getSystemIcon(file);
        java.awt.Image image = icon.getImage();
        BufferedImage buffer = new BufferedImage(
            image.getWidth(null),
            image.getHeight(null),
            BufferedImage.TYPE_INT_RGB
        );
        return SwingFXUtils.toFXImage(buffer, null);
    }

    @FXML
    private void accionBorrar(ActionEvent event) {
    }

    @FXML
    private void accionNuevo(ActionEvent event) {
    }

    @FXML
    private void accionEditar(ActionEvent event) {
    }

    @FXML
    private void accionUpdate(ActionEvent event) {
    }

    @FXML
    private void accionCommit(ActionEvent event) {
    }
    
}
