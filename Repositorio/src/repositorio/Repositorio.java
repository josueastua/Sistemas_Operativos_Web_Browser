/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio;

import javafx.application.Application;
import javafx.stage.Stage;
import repositorio.util.FlowController;

/**
 *
 * @author IVAN
 */
public class Repositorio extends Application {
    
    @Override
    public void start(Stage stage) throws Exception {
        FlowController.getInstance().goViewInNoResizableWindow("Login", Boolean.TRUE);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
