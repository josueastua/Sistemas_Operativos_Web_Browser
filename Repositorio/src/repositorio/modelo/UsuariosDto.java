/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.modelo;

import java.util.List;

/**
 *
 * @author IVAN
 */
public class UsuariosDto {
    private Integer usuId;
    private String usuNombre;
    private String usuPassword;
    private String usuDir;
    private List<VersionesDto> versiones;
    private List<PermisosDto> permisosDados;
    private List<PermisosDto> permisosOtorgados;
    
    public UsuariosDto(){}
    
    public UsuariosDto(Usuarios usu){
        this.usuId = usu.getUsuId();
        this.usuNombre = usu.getUsuNombre();
        this.usuPassword = usu.getUsuPassword();
        this.usuDir = usu.getUsuDir();
    }
    

    public Integer getUsuId() {
        return usuId;
    }

    public void setUsuId(Integer usuId) {
        this.usuId = usuId;
    }

    public String getUsuNombre() {
        return usuNombre;
    }

    public void setUsuNombre(String usuNombre) {
        this.usuNombre = usuNombre;
    }

    public String getUsuPassword() {
        return usuPassword;
    }

    public void setUsuPassword(String usuPassword) {
        this.usuPassword = usuPassword;
    }

    public String getUsuDir() {
        return usuDir;
    }

    public void setUsuDir(String usuDir) {
        this.usuDir = usuDir;
    }

    public List<VersionesDto> getVersiones() {
        return versiones;
    }

    public void setVersiones(List<VersionesDto> versiones) {
        this.versiones = versiones;
    }

    public List<PermisosDto> getPermisosDados() {
        return permisosDados;
    }

    public void setPermisosDados(List<PermisosDto> permisosDados) {
        this.permisosDados = permisosDados;
    }

    public List<PermisosDto> getPermisosOtorgados() {
        return permisosOtorgados;
    }

    public void setPermisosOtorgados(List<PermisosDto> permisosOtorgados) {
        this.permisosOtorgados = permisosOtorgados;
    }
    
    
}
