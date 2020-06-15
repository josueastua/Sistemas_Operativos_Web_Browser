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
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.control.ScrollPane;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.image.PixelWriter;
import javafx.scene.image.WritableImage;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.VBox;
import javax.swing.ImageIcon;
import javax.swing.filechooser.FileSystemView;
import repositorio.Repositorio;
import repositorio.util.AppContext;
import repositorio.util.FlowController;



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
    @FXML private JFXButton btnAbrir;
    @FXML private JFXButton btnUpdate;
    @FXML private JFXButton btnCommit;
    @FXML private ScrollPane spContenedor;
    private GridPane ventana;
    @FXML
    private VBox vbScroll;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    } 
    
    private void cargarCarpeta(File file){
        List<File> files = new ArrayList<>();
        try{
            DirectoryStream<Path> contenido = Files.newDirectoryStream(file.toPath());
            for(Path ruta: contenido){
                files.add(new File(ruta.toString()));
                System.out.println(ruta);
            }
            ventana = new GridPane();
            ventana.alignmentProperty().set(Pos.TOP_LEFT);
            int filas = files.size()/6;
            if(files.size() % 6 != 0)
                filas ++;
            FXMLLoader loader;
            List<Object> lista = new ArrayList<>();
            int index = 0;
            for(int i = 0; i < filas; i++){
                for(int j = 0; j < 6; j++){
                    if(index < files.size()){
                        lista.clear();
                        System.out.println(files.get(index).getName());
                        lista.add(files.get(index));
                        lista.add(files.get(index).getName());
                        lista.add(convertirImage(files.get(index)));
                        AppContext.getInstance().set("Parametros", lista);
                    }else{
                        if(!lista.isEmpty()){
                            lista.clear();
                            AppContext.getInstance().set("Parametros", lista);
                        }
                    }
                    if(index < files.size()){
                        loader = new FXMLLoader(Repositorio.class.getResource("view/Casilla.fxml"));
                        loader.load();
                        CasillaController cont = loader.getController();
                        cont.intermedio();
                        ventana.add(loader.getRoot(), j, i);
                    }
                    index++;
                }
            }
            vbScroll.getChildren().clear();
            vbScroll.getChildren().add(ventana);
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

    @Override
    public void initialize() {
        cargarCarpeta(new File("C:\\raiz"));
    }
    
}
