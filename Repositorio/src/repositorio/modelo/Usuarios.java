/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.modelo;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author IVAN
 */
@Entity
@Table(name = "usuarios")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Usuarios.findAll", query = "SELECT u FROM Usuarios u")
    , @NamedQuery(name = "Usuarios.findByUsuId", query = "SELECT u FROM Usuarios u WHERE u.usuId = :usuId")
    , @NamedQuery(name = "Usuarios.findByUsuNombre", query = "SELECT u FROM Usuarios u WHERE u.usuNombre = :usuNombre")
    , @NamedQuery(name = "Usuarios.findByUsuNombreLike", query = "SELECT u FROM Usuarios u WHERE u.usuNombre like :usuNombre")
    , @NamedQuery(name = "Usuarios.findByUsuPassword", query = "SELECT u FROM Usuarios u WHERE u.usuPassword = :usuPassword")
    , @NamedQuery(name = "Usuarios.findByUsuDir", query = "SELECT u FROM Usuarios u WHERE u.usuDir = :usuDir")
    , @NamedQuery(name = "Usuarios.userLogin", query = "SELECT u FROM Usuarios u WHERE u.usuNombre = :usuNombre and u.usuPassword = :usuPassword")
})
public class Usuarios implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "UsuId")
    private Integer usuId;
    @Basic(optional = false)
    @Column(name = "UsuNombre")
    private String usuNombre;
    @Basic(optional = false)
    @Column(name = "UsuPassword")
    private String usuPassword;
    @Basic(optional = false)
    @Column(name = "UsuDir")
    private String usuDir;

    public Usuarios() {
    }

    public Usuarios(Integer usuId) {
        this.usuId = usuId;
    }

    public Usuarios(Integer usuId, String usuNombre, String usuPassword, String usuDir) {
        this.usuId = usuId;
        this.usuNombre = usuNombre;
        this.usuPassword = usuPassword;
        this.usuDir = usuDir;
    }
    
    public Usuarios(UsuariosDto usu){
        this.usuId = usu.getUsuId();
        Actualizar(usu);
    }
    
    public void Actualizar(UsuariosDto usu){
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

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (usuId != null ? usuId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Usuarios)) {
            return false;
        }
        Usuarios other = (Usuarios) object;
        if ((this.usuId == null && other.usuId != null) || (this.usuId != null && !this.usuId.equals(other.usuId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "repositorio.modelo.Usuarios[ usuId=" + usuId + " ]";
    }
    
}
