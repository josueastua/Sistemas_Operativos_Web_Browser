/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.service;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.NoResultException;
import javax.persistence.Query;
import repositorio.modelo.Versiones;
import repositorio.modelo.VersionesDto;
import repositorio.util.EntityManagerHelper;
import repositorio.util.Respuesta;

/**
 *
 * @author IVAN
 */
public class VersionesService {
    
    EntityManager em = EntityManagerHelper.getInstance().getManager();
    private EntityTransaction et;
    
    public Respuesta getVersionesByUsuario(int usuid){//Los permisos que le han otorgado al usuario
        try{
            Query query = em.createNamedQuery("Versiones.findByVerIdUsuario", Versiones.class);
            query.setParameter("verIdUsuario", usuid);
            return new Respuesta(true, "", "", "Versiones", convertirLista((List<Versiones>)query.getResultList()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No se encontraron coincidencias", "getVersionesByUsuario NoResultException");
        }catch(Exception ex){
            Logger.getLogger(PermisosServices.class.getName()).log(Level.SEVERE, "Ocurrio un error al obtener las versiones.", ex);
            return new Respuesta(false, "Ocurrio un error al obtener las versiones.", "getVersionesByUsuario " + ex.getMessage());
        }
    }
    
    public Respuesta guardarVersion(VersionesDto ver){
        try{
            et = em.getTransaction();
            et.begin();
            Versiones ent;
            if(ver.getVerId()!= null && ver.getVerId()> 0){
                ent = em.find(Versiones.class, ver.getVerId());
                if(ent == null){
                    et.rollback();
                    return new Respuesta(false, "No se encontro la version a modificar", "guardarVersion NoResultException");
                }
                ent.Actualizar(ver);
                ent = em.merge(ent);
            }else{
                ent = new Versiones(ver);
                em.persist(ent);
            }
            et.commit();
            return new Respuesta(true, "", "", "Versiones", new VersionesDto(ent));
        }catch(Exception ex){
            et.rollback();
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al guardar la version .", ex);
            return new Respuesta(false, "Ocurrio un error al guardar la version.", "guardarVersion" + ex.getMessage());
        }
    }
    
    private List<VersionesDto> convertirLista(List<Versiones> lista){
        List<VersionesDto> retorno = new ArrayList<>();
        lista.forEach( (entity) -> {
            retorno.add(new VersionesDto(entity));
        });
        return retorno;
    }
}
