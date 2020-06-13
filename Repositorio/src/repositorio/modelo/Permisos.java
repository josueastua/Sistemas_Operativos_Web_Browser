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
@Table(name = "permisos")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Permisos.findAll", query = "SELECT p FROM Permisos p")
    , @NamedQuery(name = "Permisos.findByPerId", query = "SELECT p FROM Permisos p WHERE p.perId = :perId")
    , @NamedQuery(name = "Permisos.findByPerTipo", query = "SELECT p FROM Permisos p WHERE p.perTipo = :perTipo")
    , @NamedQuery(name = "Permisos.findByPerUsuario", query = "SELECT p FROM Permisos p WHERE p.perUsuario = :perUsuario")
    , @NamedQuery(name = "Permisos.findByPerDueno", query = "SELECT p FROM Permisos p WHERE p.perDueno = :perDueno")})
public class Permisos implements Serializable {

    

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "perId")
    private Integer perId;
    @Basic(optional = false)
    @Column(name = "perTipo")
    private int perTipo;
    @Basic(optional = false)
    @Column(name = "perUsuario")
    private int perUsuario;
    @Basic(optional = false)
    @Column(name = "perDueno")
    private String perDueno;

    public Permisos() {
    }

    public Permisos(Integer perId) {
        this.perId = perId;
    }

    public Permisos(Integer perId, int perTipo, int perUsuario, String perDueno) {
        this.perId = perId;
        this.perTipo = perTipo;
        this.perUsuario = perUsuario;
        this.perDueno = perDueno;
    }
    
    public Permisos(PermisosDto per){
        this.perId = per.getPerId();
        Actualizar(per);
    }
    
    public void Actualizar(PermisosDto per){
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


    @Override
    public int hashCode() {
        int hash = 0;
        hash += (perId != null ? perId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Permisos)) {
            return false;
        }
        Permisos other = (Permisos) object;
        if ((this.perId == null && other.perId != null) || (this.perId != null && !this.perId.equals(other.perId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "repositorio.modelo.Permisos[ perId=" + perId + " ]";
    }

    public String getPerDueno() {
        return perDueno;
    }

    public void setPerDueno(String perDueno) {
        this.perDueno = perDueno;
    }
    
}
