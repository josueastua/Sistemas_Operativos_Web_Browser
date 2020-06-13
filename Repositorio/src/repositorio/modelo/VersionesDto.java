/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.modelo;

/**
 *
 * @author IVAN
 */
public class VersionesDto {
    private Integer verId;
    private String verArchivo;
    private String verCarpeta;
    private int verIdUsuario;
    
    public VersionesDto(){}
    
    public VersionesDto(Versiones ver){
        this.verId = ver.getVerId();
        this.verArchivo = ver.getVerArchivo();
        this.verCarpeta = ver.getVerCarpeta();
        this.verIdUsuario = ver.getVerIdUsuario();
    }

    public Integer getVerId() {
        return verId;
    }

    public void setVerId(Integer verId) {
        this.verId = verId;
    }

    public String getVerArchivo() {
        return verArchivo;
    }

    public void setVerArchivo(String verArchivo) {
        this.verArchivo = verArchivo;
    }

    public String getVerCarpeta() {
        return verCarpeta;
    }

    public void setVerCarpeta(String verCarpeta) {
        this.verCarpeta = verCarpeta;
    }

    public int getVerIdUsuario() {
        return verIdUsuario;
    }

    public void setVerIdUsuario(int verIdUsuario) {
        this.verIdUsuario = verIdUsuario;
    }
}
