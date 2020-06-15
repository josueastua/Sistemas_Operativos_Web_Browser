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
import java.io.IOException;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import javafx.embed.swing.SwingFXUtils;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Alert;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;
import javafx.scene.image.Image;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.BorderPane;
import javax.swing.filechooser.FileSystemView;
import repositorio.Repositorio;
import repositorio.modelo.Usuarios;
import repositorio.modelo.UsuariosDto;
import repositorio.util.AppContext;
import repositorio.util.Mensaje;



/**
 * FXML Controller class
 *
 * @author IVAN
 */
public class AdministradorController extends Controller implements Initializable {

    @FXML private BorderPane bpAdmRoot;
    @FXML private JFXButton btnBorrar;
    @FXML private JFXButton btnEditar;
    @FXML private JFXButton btnUpdate;
    @FXML private JFXButton btnCommit;
    @FXML private ListView<CasillaController> lvArchivos;
    @FXML private JFXButton btnAtras;
    @FXML private ComboBox<String> cbNuevo;
    private HashMap<String, String> ext = new HashMap();
    List<CasillaController> controladores = new ArrayList<>();
    private File actual;
    Mensaje men;
    @FXML
    private JFXButton btnGuardar;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        men = new Mensaje();
    } 
    private void cargarCarpeta(File file){
        List<Object> lista = new ArrayList<>();
        File archivo;
        FXMLLoader loader;
        lvArchivos.getItems().clear();
        controladores.clear();
        try{
            DirectoryStream<Path> contenido = Files.newDirectoryStream(file.toPath());
            for(Path ruta: contenido){
                lista.clear();
                archivo = new File(ruta.toString());
                lista.add(archivo);
                lista.add(archivo.getName());
                lista.add(convertirImage(archivo));
                AppContext.getInstance().set("Parametros", lista);
                loader = new FXMLLoader(Repositorio.class.getResource("view/Casilla.fxml"));
                loader.load();
                CasillaController cont = loader.getController();
                cont.intermedio();
                controladores.add(cont);
                lvArchivos.getItems().add(loader.getRoot());
            }
            actual = file;
        }catch(IOException ex){}
    }
    
    private Image convertirImage(File file){
        javax.swing.Icon icon = FileSystemView.getFileSystemView().getSystemIcon(file);
        BufferedImage buffer = new BufferedImage(
            icon.getIconWidth(),
            icon.getIconWidth(),
            BufferedImage.TYPE_INT_ARGB
        );
        icon.paintIcon(null, buffer.getGraphics(), 0, 0);
        Image image = SwingFXUtils.toFXImage(buffer, null);
        return image;
    }

    @FXML
    private void accionBorrar(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            
        }else
            men.show(Alert.AlertType.INFORMATION, "Borrar", "No tiene permisos para borrar aqui");
    }

    private void accionNuevo(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            
        }else
            men.show(Alert.AlertType.INFORMATION, "Nuevo", "No tiene permisos para crear aqui");
    }

    @FXML
    private void accionEditar(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            
        }else
            men.show(Alert.AlertType.INFORMATION, "Editar", "No tiene permisos para editar aqui");
    }

    @FXML
    private void accionUpdate(ActionEvent event) {
        
    }

    @FXML
    private void accionCommit(ActionEvent event) {
        
    }

    @Override
    public void initialize() {
        UsuariosDto user = (UsuariosDto) AppContext.getInstance().get("User");
        cargarCarpeta(new File("C:\\raiz"));
        cbNuevo.getItems().add("Imagen .jpg");
        ext.put("Imagen .jpg", ".jpg");
        cbNuevo.getItems().add("Imagen .png");
        ext.put("Imagen .png", ".png");
        cbNuevo.getItems().add("Imagen .jpeg");
        ext.put("Imagen .jpeg", ".jpeg");
        cbNuevo.getItems().add("Imagen .gif");
        ext.put("Imagen .gif", ".gif");
        
        cbNuevo.getItems().add("Texto .doc");
        ext.put("Texto .doc", ".doc");
        cbNuevo.getItems().add("Textp .docx");
        ext.put("Texto .docx", ".docx");
        cbNuevo.getItems().add("Texto .pdf");
        ext.put("Texto .pdf", ".pdf");
        
        cbNuevo.getItems().add("Media .mp3");
        ext.put("Media .mp3", ".mp3");
        cbNuevo.getItems().add("Media .mp4");
        ext.put("Media .mp4", ".mp4");
        
        cbNuevo.getItems().add("Presentacion .ppt");
        ext.put("Presentacion .ppt", ".ppt");
        cbNuevo.getItems().add("Presentacion .pptx");
        ext.put("Presentacion .pptx", ".pptx");
        
        cbNuevo.getItems().add("Comprimido .zip");
        ext.put("Comprimido .zip", ".zip");
        cbNuevo.getItems().add("Comprimido .rar");
        ext.put("Comprimido .rar", ".rar");
        
        cbNuevo.getItems().add("Hojas de calculo .xls");
        ext.put("Hojas de calculo .xls", ".xls");
        cbNuevo.getItems().add("Hojas de calculo .xlsx");
        ext.put("Hojas de calculo .xlsx", ".xlsx");
    }

    @FXML
    private void accionList(MouseEvent event) {
        if(lvArchivos.getSelectionModel().getSelectedItem() != null){
            CasillaController aux = controladores.get(lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem()));
            if(aux.isDirectorio())
                cargarCarpeta(aux.getFile());
        }else
            men.show(Alert.AlertType.ERROR, "Seleccion", "No selecciona un archivo");
    }

    @FXML
    private void accionAtras(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            File file = actual.getParentFile();
            if(!file.getAbsolutePath().equals("C:\\")){
                cargarCarpeta(file);
            }
        }else
            men.show(Alert.AlertType.INFORMATION, "Atras", "Ya no hay mas atras");
    }

    @FXML
    private void accionCombo(ActionEvent event) {
    }

    @FXML
    private void accionGuardar(ActionEvent event) {
    }
    
}
