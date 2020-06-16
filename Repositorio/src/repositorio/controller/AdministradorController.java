/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.controller;


import com.jfoenix.controls.JFXButton;
import java.awt.Desktop;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.Initializable;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.nio.file.CopyOption;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
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
import javafx.stage.FileChooser;
import javax.swing.filechooser.FileSystemView;
import repositorio.Repositorio;
import repositorio.modelo.PapeleraDto;
import repositorio.modelo.PermisosDto;
import repositorio.modelo.Usuarios;
import repositorio.modelo.UsuariosDto;
import repositorio.service.PapeleraService;
import repositorio.util.AppContext;
import repositorio.util.Mensaje;
import repositorio.util.Respuesta;



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
    @FXML private JFXButton btnGuardar;
    private HashMap<String, String> ext = new HashMap();
    private List<CasillaController> controladores = new ArrayList<>();
    private File actual;
    private Mensaje men;
    private UsuariosDto user;
    private Boolean propiaCarpeta;
    @FXML private JFXButton btnAbrir;
    PapeleraService service = new PapeleraService();
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        men = new Mensaje();
        propiaCarpeta = Boolean.FALSE;
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
                if(ruta != null){
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
            }
            actual = file;
        }catch(IOException ex){}
    }
    
    public void crearRepresentacion(File archivo){
        try {
            List<Object> lista = new ArrayList<>();
            lista.add(archivo);
            lista.add(archivo.getName());
            lista.add(convertirImage(archivo));
            AppContext.getInstance().set("Parametros", lista);
            FXMLLoader loader = new FXMLLoader(Repositorio.class.getResource("view/Casilla.fxml"));
            loader.load();
            CasillaController cont = loader.getController();
            cont.intermedio();
            controladores.add(cont);
            lvArchivos.getItems().add(loader.getRoot());
        } catch (IOException ex) {
            Logger.getLogger(AdministradorController.class.getName()).log(Level.SEVERE, null, ex);
            men.show(Alert.AlertType.INFORMATION, "Cargar Representacion", "Ocurrio un error al cargar la representacion: "+ex);
        }
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
        if(!actual.getAbsolutePath().equals("C:\\raiz") && !actual.getAbsolutePath().contains("Permanente")){
            if(lvArchivos.getSelectionModel().getSelectedItem() != null){
                CasillaController aux = controladores.get(lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem()));
                if(propiaCarpeta || verificarAccion(4)){
                    if(!aux.getFile().isDirectory()){
                        try {
                            int index = lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem());
                            File file = aux.getFile();
                            Path destino = Paths.get("C:\\raiz\\Papelera\\"), origen;
                            origen = Paths.get(file.getAbsolutePath());
                            Files.move(origen, destino.resolve(origen.getFileName()));
                            PapeleraDto pap = new PapeleraDto(user.getUsuId(), actual.getAbsolutePath(), "C:\\raiz\\Papelera\\"+file.getName());
                            Respuesta res = service.guardarPapelera(pap);
                            if(res.getEstado()){
                                System.out.println("Exito");
                                user.getPapelera().add((PapeleraDto) res.getResultado("Papelera"));
                            }
                            lvArchivos.getItems().remove(index);
                        } catch (IOException ex) {
                            Logger.getLogger(AdministradorController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    }else if(aux.getFile().isDirectory()){
                        List<File> lista = new ArrayList<>();
                        List<DirectoryStream<Path>> cont  = new ArrayList<>();
                        int index = lvArchivos.getSelectionModel().getSelectedIndex();
                        moverDirectorio(cont, lista, "C:\\raiz\\Papelera\\", aux.getFile());
                        for(DirectoryStream<Path> c:cont){
                            try {
                                c.close();
                            } catch (IOException ex) {
                                Logger.getLogger(AdministradorController.class.getName()).log(Level.SEVERE, null, ex);
                            }
                        }
                        for(File file : lista){
                            try{
                                file.delete();
                            }catch(Exception ex){}
                        }
                        lvArchivos.getItems().remove(index);
                    }
                }else{
                    men.show(Alert.AlertType.INFORMATION, "Abrir Archivo", "No posee los permisos");
                }
            }
        }else{
            event.consume();
            men.show(Alert.AlertType.INFORMATION, "Borrar", "No tiene permisos para borrar aqui");
        }
    }
    
    public void moverDirectorio(List<DirectoryStream<Path>> contenidos, List<File> lista, String carpeta, File file){
        lista.add(0, file);
        File papelera = new File(carpeta+file.getName());
        if(!papelera.exists()){
            papelera.mkdir();
        }
        try {
            File cont;
            DirectoryStream<Path> contenido = Files.newDirectoryStream(file.toPath());
            contenidos.add(0, contenido);
            for(Path ruta : contenido){
                cont = new File(ruta.toString());
                if(cont.isFile()){
                    Path destino = Paths.get(papelera.getAbsolutePath()+"\\"), origen;
                    origen = Paths.get(cont.getAbsolutePath());
                    Files.move(origen, destino.resolve(origen.getFileName()));
                    PapeleraDto pap = new PapeleraDto(user.getUsuId(), actual.getAbsolutePath(), papelera.getAbsolutePath()+"\\"+file.getName());
                    Respuesta res = service.guardarPapelera(pap);
                    if(res.getEstado()){
                        System.out.println("Exito");
                        user.getPapelera().add((PapeleraDto) res.getResultado("Papelera"));
                    }
                }else if(cont.isDirectory()){
                    moverDirectorio(contenidos, lista, papelera.getAbsolutePath()+"\\" ,cont);
                }
            }
            
        } catch (IOException ex) {}
    }

    @FXML
    private void accionEditar(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz") && !actual.getAbsolutePath().contains("Permanente")){
            if(lvArchivos.getSelectionModel().getSelectedItem() != null){
                CasillaController aux = controladores.get(lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem()));
                if(propiaCarpeta || verificarAccion(4)){
                    File file = aux.getFile();
                    try{
                        Desktop.getDesktop().edit(file); 
                    }catch(IOException ex){
                        men.show(Alert.AlertType.INFORMATION, "Abrir Archivo", "No se pudo abrir el archivo");
                    }
                }else{
                    men.show(Alert.AlertType.INFORMATION, "Abrir Archivo", "No posee los permisos");
                }
            }
        }else
            men.show(Alert.AlertType.INFORMATION, "Editar", "No tiene permisos para editar aqui");
    }

    @FXML
    private void accionUpdate(ActionEvent event) {
        System.out.println(actual);
        if(actual.getAbsolutePath().contains("Temporal")){
            if(propiaCarpeta){
                if(men.showConfirmation("Update", this.getStage(), "Si hay archivos el temporal se perderan")){
                    List<File> lista = new ArrayList<>();
                    List<DirectoryStream<Path>> cont  = new ArrayList<>();
                    borrarDirectorio(cont, lista, new File("C:\\raiz\\"+user.getUsuNombre()+"\\Temporal"));
                    borrarDirectorio(cont, lista, actual);
                    for(DirectoryStream<Path> c:cont){
                        try {
                            c.close();
                        } catch (IOException ex) {
                            Logger.getLogger(AdministradorController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    }
                    for(File file : lista){
                        try{
                            file.delete();
                        }catch(Exception ex){}
                    }
                    moverDirectorio("C:\\raiz\\"+user.getUsuNombre()+"\\Permanente", actual);
                }
            }
        }else{
            men.show(Alert.AlertType.INFORMATION, "Update", "Debe encontrarse el la carpeta Temporal");
        }
    }
    
    public void borrarDirectorio(List<DirectoryStream<Path>> contenidos, List<File> lista, File file){
        if(!file.getName().equals("Temporal"))    
            lista.add(0, file);
        try {
            File cont;
            DirectoryStream<Path> contenido = Files.newDirectoryStream(file.toPath());
            contenidos.add(0, contenido);
            for(Path ruta : contenido){
                cont = new File(ruta.toString());
                if(cont.isFile()){
                    Path destino = Paths.get("C:\\raiz\\Papelera\\"+file.getName()), origen;
                    origen = Paths.get(cont.getAbsolutePath());
                    Files.move(origen, destino.resolve(origen.getFileName()));
                    if(cont.delete())
                        System.out.println("Archivo borrado");
                }else if(cont.isDirectory()){
                    borrarDirectorio(contenidos, lista, cont);
                }
            }
        } catch (IOException ex) {}
    }
    
    public void moverDirectorio(String Carpeta, File file){
        try {
            File cont;
            DirectoryStream<Path> contenido = Files.newDirectoryStream(file.toPath());
            for(Path ruta : contenido){
                cont = new File(ruta.toString());
                if(cont.isFile()){
                    Path destino = Paths.get(Carpeta+file.getName()), origen;
                    origen = Paths.get(cont.getAbsolutePath());
                    Files.move(origen, destino.resolve(origen.getFileName()));
                    if(file.delete())
                        System.out.println("Archivo borrado");
                }else if(cont.isDirectory()){
                    moverDirectorio(Carpeta+file.getName(), cont);
                }
            }
        } catch (IOException ex) {}
    }

    @FXML
    private void accionCommit(ActionEvent event) {
        if(!actual.getAbsolutePath().contains("Temporal")){
            
        }else{
            men.show(Alert.AlertType.INFORMATION, "Update", "Debe encontrarse el la carpeta Temporal");
        }
        
    }

    @Override
    public void initialize() {
        user = (UsuariosDto) AppContext.getInstance().get("User");
        cargarCarpeta(new File("C:\\raiz"));
        cbNuevo.getItems().add("Nueva Carpeta");
        ext.put("Nueva Carpeta", "carpeta");
        
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
        cbNuevo.getItems().add("Texto .docx");
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
        
        cbNuevo.getItems().add("Hojas de calculo .xls");
        ext.put("Hojas de calculo .xls", ".xls");
        cbNuevo.getItems().add("Hojas de calculo .xlsx");
        ext.put("Hojas de calculo .xlsx", ".xlsx");
    }

    @FXML
    private void accionList(MouseEvent event) {
        if(lvArchivos.getSelectionModel().getSelectedItem() != null && event.getClickCount() == 2){
            CasillaController aux = controladores.get(lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem()));
            if(aux.isDirectorio()){
                if(actual.getAbsolutePath().equals("C:\\raiz")){
                    if(verificarTienePermisos(aux.getNombre())){
                        cargarCarpeta(aux.getFile());
                    }else{
                        men.show(Alert.AlertType.INFORMATION, "Permisos", "No posee los permisos para entrar");
                    }     
                }else{
                    if(aux.getFile().getAbsolutePath().contains("Permanente")){
                        men.show(Alert.AlertType.WARNING, "Carpeta Permanente", "Solo puede ver el contenido de esta carpeta");
                        cargarCarpeta(aux.getFile());
                    }else if(aux.getFile().getAbsolutePath().contains("Versiones")){
                        men.show(Alert.AlertType.WARNING, "Carpeta Versiones", "No se puede acceder a esta carpeta");
                    }else if(aux.getFile().getAbsolutePath().contains("Temporal")){
                        if(aux.getFile().getParentFile().getParent().equals("C:\\raiz"))
                            men.show(Alert.AlertType.WARNING, "Carpeta Temporal", "Aqui puede cargar, crear o borrar archivos\nUse el boton Update para cargar los archivo de carpeta permanente\nUse el boton commit para guradarlos");
                        cargarCarpeta(aux.getFile());
                    }
                }
            }
        }else if(lvArchivos.getSelectionModel().getSelectedItem() == null)
            men.show(Alert.AlertType.ERROR, "Seleccion", "No selecciona un archivo");
    }

    @FXML
    private void accionAtras(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            File file = actual.getParentFile();
            if(!file.getAbsolutePath().equals("C:\\")){
                cargarCarpeta(file);
            }
        }else{
            propiaCarpeta = Boolean.FALSE;
            men.show(Alert.AlertType.INFORMATION, "Atras", "Ya no hay mas atras");
        }
    }

    @FXML
    private void accionCombo(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz") && !actual.getAbsolutePath().contains("Permanente")){
            if(cbNuevo.getSelectionModel().getSelectedItem() != null){
                if(propiaCarpeta || verificarAccion(1)){
                    String extension = ext.get(cbNuevo.getSelectionModel().getSelectedItem());
                    if(!extension.equals("carpeta")){
                        String nombre = men.textInputDialog("Crear archivo", "Ingrese el nombre");
                        if(!nombre.isEmpty()){
                            try{
                                File file = new File(actual.getAbsolutePath()+"\\"+nombre+extension);
                                if(!file.exists()){
                                    file.createNewFile();
                                    crearRepresentacion(file);
                                }else{
                                    men.show(Alert.AlertType.INFORMATION, "Crear archivo", "El archivo ya existe");
                                }
                            }catch(IOException ex){
                                men.show(Alert.AlertType.INFORMATION, "Crear Archivo", "Ocurrio un error al tratar de crear el archivo");
                            }
                        }
                    }else if(extension.equals("carpeta")){
                        String nombre = men.textInputDialog("Crear carpeta", "Ingrese el nombre");
                        if(!nombre.isEmpty()){
                            File file = new File(actual.getAbsolutePath()+"\\"+nombre);
                            if(!file.exists()){
                                file.mkdir();
                                crearRepresentacion(file);
                            }else{
                                men.show(Alert.AlertType.INFORMATION, "Crear carpeta", "El una carpeta ya existe");
                            }
                        }
                    }
                }else{
                    men.show(Alert.AlertType.INFORMATION, "Crear Archivo", "No tiene permisos para crear aqui");
                }
            }
            cbNuevo.getSelectionModel().clearSelection(cbNuevo.getItems().indexOf(cbNuevo.getSelectionModel().getSelectedIndex()));
        }else{
            if(cbNuevo.getSelectionModel().getSelectedItem() != null)
                cbNuevo.getSelectionModel().clearSelection(cbNuevo.getItems().indexOf(cbNuevo.getSelectionModel().getSelectedIndex()));
            event.consume();
            men.show(Alert.AlertType.INFORMATION, "Nuevo", "No tiene permisos para crear aqui");
        }
    }

    @FXML
    private void accionGuardar(ActionEvent event) {
        if((propiaCarpeta || verificarAccion(3) && !actual.getAbsolutePath().equals("C:\\raiz"))  && !actual.getAbsolutePath().contains("Permanente")){
            FileChooser selecter = new FileChooser();
            List<File> files = selecter.showOpenMultipleDialog(this.getStage());
            Path destino = Paths.get(actual.getAbsoluteFile()+"\\"), origen;
            try{
                for(File f : files){
                    origen = Paths.get(f.getAbsolutePath());
                    Files.copy(origen, destino.resolve(origen.getFileName()));
                    crearRepresentacion(new File(actual+"\\"+f.getName()));
                }
            }catch(IOException ex){
                System.out.println(ex);
            }
        }else{
            men.show(Alert.AlertType.INFORMATION, "Nuevo", "No tiene permisos para crear aqui");
        }
    }
    
    public Boolean verificarTienePermisos(String name){
        if(name.equals(user.getUsuNombre())){
            propiaCarpeta = Boolean.TRUE;
            return true;
        }
        for(PermisosDto per: user.getPermisosDados()){
            if(per.getPerDueno().equals(name)){
                propiaCarpeta = Boolean.FALSE;
                return true;
            }
        }
        return false;
    }
    
    public Boolean verificarAccion(int accion){
        PermisosDto per = buscarPermiso();
        if(per != null){
            switch(accion){
            case 1://Crear
                return per.getPerCrear() == 1;
            case 2://Borrar
                return per.getPerBorrar() == 1;
            case 3://Editar y cargar
                return per.getPerEditar() == 1;
            case 4://lectura
                return per.getPerLeer() == 1;
            default:
                return false;
            }
        }else{
            return false;
        }
    }
    
    private PermisosDto buscarPermiso(){
        for(PermisosDto per: user.getPermisosDados()){
            if(actual.getAbsolutePath().contains(per.getPerDueno())){
                return per;
            }
        }
        return null;
    }

    @FXML
    private void accionAbrir(ActionEvent event) {
        if(!actual.getAbsolutePath().equals("C:\\raiz")){
            if(lvArchivos.getSelectionModel().getSelectedItem() != null){
                CasillaController aux = controladores.get(lvArchivos.getItems().indexOf(lvArchivos.getSelectionModel().getSelectedItem()));
                if(propiaCarpeta || verificarAccion(4)){
                    File file = aux.getFile();
                    try{
                        Desktop.getDesktop().open(file); 
                    }catch(IOException ex){
                        men.show(Alert.AlertType.INFORMATION, "Abrir Archivo", "No se pudo abrir el archivo");
                    }
                }else{
                    men.show(Alert.AlertType.INFORMATION, "Abrir Archivo", "No posee los permisos");
                }
            }
        }else
            men.show(Alert.AlertType.INFORMATION, "Borrar", "No tiene permisos para borrar aqui");
        
    }
    
}
