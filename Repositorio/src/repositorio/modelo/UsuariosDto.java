/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.modelo;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import repositorio.util.Entidad;

/**
 *
 * @author IVAN
 */
public class UsuariosDto extends Entidad{
    private Integer usuId;
    private String usuNombre;
    private String usuPassword;
    private String usuDir;
    private HashMap<String, List<VersionesDto>> versiones = new HashMap();
    private List<VersionesDto> verlist = new ArrayList<>();
    private List<PermisosDto> permisosDados;
    private List<PermisosDto> permisosOtorgados;
    private List<PapeleraDto> papelera;
    
    public UsuariosDto(){}

    public UsuariosDto(String usuNombre, String usuPassword, String usuDir) {
        this.usuId = 0;
        this.usuNombre = usuNombre;
        this.usuPassword = usuPassword;
        this.usuDir = usuDir;
    }
    
    public UsuariosDto(Usuarios usu){
        this.usuId = usu.getUsuId();
        this.usuNombre = usu.getUsuNombre();
        this.usuPassword = usu.getUsuPassword();
        this.usuDir = usu.getUsuDir();
    }

    public List<VersionesDto> getVerlist() {
        return verlist;
    }

    public void setVerlist(List<VersionesDto> verlist) {
        this.verlist = verlist;
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

    public HashMap<String, List<VersionesDto>> getVersiones() {
        return versiones;
    }

    public void setVersiones() {
        versiones.clear();
        List<VersionesDto> aux;
        for(VersionesDto version: verlist){
            aux = new ArrayList();
            for(VersionesDto version2: verlist){
                if(version.getVerIdentificador().equals(version2.getVerIdentificador())){
                    aux.add(version2);
                }
            }
            if(this.versiones.get(version.getVerIdentificador()) == null)
                this.versiones.put(version.getVerIdentificador(), aux);
        }
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
    
    public void addPermisoDados(PermisosDto per){
        Boolean existe = false;
        int index = 0;
        for(PermisosDto perm : this.permisosDados){
            if(perm.getPerUsuario().equals(per.getPerUsuario())){
                existe = true;
                index = permisosDados.indexOf(perm);
            }
        }
        if(existe){
            permisosDados.remove(index);
            permisosDados.add(per);
        }
    }

    public void setPermisosOtorgados(List<PermisosDto> permisosOtorgados) {
        this.permisosOtorgados = permisosOtorgados;
    }

    public List<PapeleraDto> getPapelera() {
        return papelera;
    }

    public void setPapelera(List<PapeleraDto> papelera) {
        this.papelera = papelera;
    }

    @Override
    public Entidad convert() {
        return null;
    }
    
}
