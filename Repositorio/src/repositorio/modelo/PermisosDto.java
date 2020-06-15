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
public class PermisosDto {
    private Integer perId;
    private String perUsuario;
    private String perDueno;
    private int perLeer;
    private int perEditar;
    private int perBorrar;
    private int perCrear;
    
    public PermisosDto(Permisos per){
        this.perId = per.getPerId();
        this.perUsuario = per.getPerUsuario();
        this.perDueno = per.getPerDueno();
        this.perLeer = per.getPerLeer();
        this.perEditar = per.getPerEditar();
        this.perBorrar = per.getPerBorrar();
        this.perCrear = per.getPerCrear();
    }

    public Integer getPerId() {
        return perId;
    }

    public void setPerId(Integer perId) {
        this.perId = perId;
    }

    public String getPerUsuario() {
        return perUsuario;
    }

    public void setPerUsuario(String perUsuario) {
        this.perUsuario = perUsuario;
    }

    public String getPerDueno() {
        return perDueno;
    }

    public void setPerDueno(String perDueno) {
        this.perDueno = perDueno;
    }

    public int getPerLeer() {
        return perLeer;
    }

    public void setPerLeer(int perLeer) {
        this.perLeer = perLeer;
    }

    public int getPerEditar() {
        return perEditar;
    }

    public void setPerEditar(int perEditar) {
        this.perEditar = perEditar;
    }

    public int getPerBorrar() {
        return perBorrar;
    }

    public void setPerBorrar(int perBorrar) {
        this.perBorrar = perBorrar;
    }

    public int getPerCrear() {
        return perCrear;
    }

    public void setPerCrear(int perCrear) {
        this.perCrear = perCrear;
    }
}
