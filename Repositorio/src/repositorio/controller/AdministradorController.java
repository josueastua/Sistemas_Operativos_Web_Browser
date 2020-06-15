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
import java.util.List;
import javafx.embed.swing.SwingFXUtils;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Alert;
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
    @FXML private JFXButton btnNuevo;
    @FXML private JFXButton btnEditar;
    @FXML private JFXButton btnUpdate;
    @FXML private JFXButton btnCommit;
    @FXML private ListView<CasillaController> lvArchivos;
    List<CasillaController> controladores = new ArrayList<>();
    private File actual;
    Mensaje men;
    @FXML private JFXButton btnAtras;
    
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

    @FXML
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
    
}
