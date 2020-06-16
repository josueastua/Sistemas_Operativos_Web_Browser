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
@Table(name = "versiones")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Versiones.findAll", query = "SELECT v FROM Versiones v")
    , @NamedQuery(name = "Versiones.findByVerId", query = "SELECT v FROM Versiones v WHERE v.verId = :verId")
    , @NamedQuery(name = "Versiones.findByVerArchivo", query = "SELECT v FROM Versiones v WHERE v.verArchivo = :verArchivo")
    , @NamedQuery(name = "Versiones.findByVerCarpeta", query = "SELECT v FROM Versiones v WHERE v.verCarpeta = :verCarpeta")
    , @NamedQuery(name = "Versiones.findByVerIdUsuario", query = "SELECT v FROM Versiones v WHERE v.verIdUsuario = :verIdUsuario")})
public class Versiones implements Serializable {

    

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "verId")
    private Integer verId;
    @Basic(optional = false)
    @Column(name = "verArchivo")
    private String verArchivo;
    @Basic(optional = false)
    @Column(name = "verCarpeta")
    private String verCarpeta;
    @Basic(optional = false)
    @Column(name = "verIdentificador")
    private String verIdentificador;
    @Basic(optional = false)
    @Column(name = "verIdUsuario")
    private String verIdUsuario;

    public Versiones() {
    }

    public Versiones(Integer verId) {
        this.verId = verId;
    }

    public Versiones(Integer verId, String verArchivo, String verCarpeta, String verIdUsuario) {
        this.verId = verId;
        this.verArchivo = verArchivo;
        this.verCarpeta = verCarpeta;
        this.verIdUsuario = verIdUsuario;
    }

    public Versiones(VersionesDto ver){
        this.verId = ver.getVerId();
        Actualizar(ver);
    }
    
    public void Actualizar(VersionesDto ver) {
        this.verArchivo = ver.getVerArchivo();
        this.verCarpeta = ver.getVerCarpeta();
        this.verIdUsuario = ver.getVerIdUsuario();
        this.verIdentificador = ver.getVerIdentificador();
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


    @Override
    public int hashCode() {
        int hash = 0;
        hash += (verId != null ? verId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Versiones)) {
            return false;
        }
        Versiones other = (Versiones) object;
        if ((this.verId == null && other.verId != null) || (this.verId != null && !this.verId.equals(other.verId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "repositorio.modelo.Versiones[ verId=" + verId + " ]";
    }

    public String getVerIdentificador() {
        return verIdentificador;
    }

    public void setVerIdentificador(String verIdentificador) {
        this.verIdentificador = verIdentificador;
    }

    public String getVerIdUsuario() {
        return verIdUsuario;
    }

    public void setVerIdUsuario(String verIdUsuario) {
        this.verIdUsuario = verIdUsuario;
    }
    
}
