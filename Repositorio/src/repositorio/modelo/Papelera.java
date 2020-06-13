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
@Table(name = "papelera")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Papelera.findAll", query = "SELECT p FROM Papelera p")
    , @NamedQuery(name = "Papelera.findByPapId", query = "SELECT p FROM Papelera p WHERE p.papId = :papId")
    , @NamedQuery(name = "Papelera.findByPapIdUser", query = "SELECT p FROM Papelera p WHERE p.papIdUser = :papIdUser")
    , @NamedQuery(name = "Papelera.findByPapDir", query = "SELECT p FROM Papelera p WHERE p.papDir = :papDir")
    , @NamedQuery(name = "Papelera.findByPapNombreArch", query = "SELECT p FROM Papelera p WHERE p.papNombreArch = :papNombreArch")})
public class Papelera implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "papId")
    private Integer papId;
    @Basic(optional = false)
    @Column(name = "papIdUser")
    private int papIdUser;
    @Basic(optional = false)
    @Column(name = "papDir")
    private String papDir;
    @Basic(optional = false)
    @Column(name = "papNombreArch")
    private String papNombreArch;

    public Papelera() {
    }

    public Papelera(Integer papId) {
        this.papId = papId;
    }

    public Papelera(Integer papId, int papIdUser, String papDir, String papNombreArch) {
        this.papId = papId;
        this.papIdUser = papIdUser;
        this.papDir = papDir;
        this.papNombreArch = papNombreArch;
    }

    public Papelera(PapeleraDto pap){
        this.papId = pap.getPapId();
        Actualizar(pap);
    }
    
    public void Actualizar(PapeleraDto pap){
        this.papIdUser = pap.getPapIdUser();
        this.papDir = pap.getPapDir();
        this.papNombreArch = pap.getPapNombreArch();
    }
    
    public Integer getPapId() {
        return papId;
    }

    public void setPapId(Integer papId) {
        this.papId = papId;
    }

    public int getPapIdUser() {
        return papIdUser;
    }

    public void setPapIdUser(int papIdUser) {
        this.papIdUser = papIdUser;
    }

    public String getPapDir() {
        return papDir;
    }

    public void setPapDir(String papDir) {
        this.papDir = papDir;
    }

    public String getPapNombreArch() {
        return papNombreArch;
    }

    public void setPapNombreArch(String papNombreArch) {
        this.papNombreArch = papNombreArch;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (papId != null ? papId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Papelera)) {
            return false;
        }
        Papelera other = (Papelera) object;
        if ((this.papId == null && other.papId != null) || (this.papId != null && !this.papId.equals(other.papId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "repositorio.modelo.Papelera[ papId=" + papId + " ]";
    }
    
}
