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
public class PapeleraDto {
    
    private Integer papId;
    private int papIdUser;
    private String papDir;
    private String papNombreArch;

    public PapeleraDto(int papIdUser, String papDir, String papNombreArch) {
        this.papId = 0;
        this.papIdUser = papIdUser;
        this.papDir = papDir;
        this.papNombreArch = papNombreArch;
    }
    
    public PapeleraDto(Papelera pap){
        this.papId = pap.getPapId();
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
    
    
}
