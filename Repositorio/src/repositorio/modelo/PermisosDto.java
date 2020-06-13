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
    private int perTipo;
    private int perUsuario;
    private String perDueno;
    
    public PermisosDto(Permisos per){
        this.perId = per.getPerId();
        this.perTipo = per.getPerTipo();
        this.perUsuario = per.getPerUsuario();
        this.perDueno = per.getPerDueno();
    }

    public Integer getPerId() {
        return perId;
    }

    public void setPerId(Integer perId) {
        this.perId = perId;
    }

    public int getPerTipo() {
        return perTipo;
    }

    public void setPerTipo(int perTipo) {
        this.perTipo = perTipo;
    }

    public int getPerUsuario() {
        return perUsuario;
    }

    public void setPerUsuario(int perUsuario) {
        this.perUsuario = perUsuario;
    }

    public String getPerDueno() {
        return perDueno;
    }

    public void setPerDueno(String perDueno) {
        this.perDueno = perDueno;
    }
    
    
}
