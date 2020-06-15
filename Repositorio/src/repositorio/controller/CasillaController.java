/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;

import java.io.File;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import org.apache.commons.io.FilenameUtils;
import repositorio.util.AppContext;

/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class CasillaController extends Controller implements Initializable {

    @FXML private Label lblNombre;
    @FXML private ImageView imvArchivo;
    private File file;
    private String nombre;
    private Image imagen;
    @FXML private Label lblExtension;

    public File getFile() {
        return file;
    }

    public void setFile(File file) {
        this.file = file;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Image getImagen() {
        return imagen;
    }

    public void setImagen(Image imagen) {
        this.imagen = imagen;
    }

    public void cargarDatos(File file, String nombre, Image imagen) {
        this.file = file;
        this.nombre = nombre;
        this.imagen = imagen;
        lblNombre.setText(nombre);
        imvArchivo.setImage(imagen);
        if(file.isFile())
            lblExtension.setText(FilenameUtils.getExtension(nombre));
        else
            lblExtension.setText("Carpeta");
    }
    
    public void intermedio(){
        List<Object> datos = (List<Object>) AppContext.getInstance().get("Parametros");
        if(!datos.isEmpty())
            cargarDatos((File)datos.get(0), (String)datos.get(1), (Image)datos.get(2));
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void accionArchivo(MouseEvent event) {
        System.out.println(nombre);
    }

    @Override
    public void initialize() {
        
    }
    
    public Boolean isDirectorio(){
        return file.isDirectory();
    }
    
}
