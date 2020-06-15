/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import java.io.File;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.VBox;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class ArchivoController extends Controller implements Initializable {

    @FXML private VBox vbContenedor;
    @FXML private ImageView imvIcono;
    @FXML private Label lblNombre;
    private File file;
    private String nombreArch;
    private Image img;

    public void cargarDatos(File file, String nombreArch, Image img) {
        this.file = file;
        this.nombreArch = nombreArch;
        this.img = img;
    }

    public VBox getVbContenedor() {
        return vbContenedor;
    }

    public File getFile() {
        return file;
    }

    public void setFile(File file) {
        this.file = file;
    }

    public String getNombreArch() {
        return nombreArch;
    }

    public void setNombreArch(String nombreArch) {
        this.nombreArch = nombreArch;
    }

    public Image getImg() {
        return img;
    }

    public void setImg(Image img) {
        this.img = img;
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }    

    @Override
    public void initialize() {
    }

    @FXML
    private void accionArchivo(MouseEvent event) {
        System.out.println("Click detected");
    }
    
}
