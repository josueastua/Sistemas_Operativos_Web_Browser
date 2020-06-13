/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package repositorio.service;

import java.sql.SQLIntegrityConstraintViolationException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.NoResultException;
import javax.persistence.Query;
import repositorio.modelo.Papelera;
import repositorio.modelo.PapeleraDto;
import repositorio.util.EntityManagerHelper;
import repositorio.util.Respuesta;

/**
 *
 * @author IVAN
 */
public class PapeleraService {
    
    EntityManager em = EntityManagerHelper.getInstance().getManager();
    private EntityTransaction et;
    
    public Respuesta getPapeleraByIdUsuario(int usuid){//Los permisos que le han otorgado al usuario
        try{
            Query query = em.createNamedQuery("Papelera.findByPapIdUser", Papelera.class);
            query.setParameter("papIdUser", usuid);
            return new Respuesta(true, "", "", "Papelera", convertirLista((List<Papelera>)query.getResultList()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No se encontraron coincidencias", "getPapeleraByIdUsuario NoResultException");
        }catch(Exception ex){
            Logger.getLogger(PermisosServices.class.getName()).log(Level.SEVERE, "Ocurrio un error al obtener la papelera.", ex);
            return new Respuesta(false, "Ocurrio un error al obtener la papelera.", "getPapeleraByIdUsuario " + ex.getMessage());
        }
    }
    
    public Respuesta guardarPapelera(PapeleraDto pap){
        try{
            et = em.getTransaction();
            et.begin();
            Papelera ent;
            if(pap.getPapId() != null && pap.getPapId() > 0){
                ent = em.find(Papelera.class, pap.getPapId());
                if(ent == null){
                    et.rollback();
                    return new Respuesta(false, "No se encontro el permiso a modificar", "guardarPermiso NoResultException");
                }
                ent.Actualizar(pap);
                ent = em.merge(ent);
            }else{
                ent = new Papelera(pap);
                em.persist(ent);
            }
            et.commit();
            return new Respuesta(true, "", "", "Usuario", new PapeleraDto(ent));
        }catch(Exception ex){
            et.rollback();
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al guardar el permiso .", ex);
            return new Respuesta(false, "Ocurrio un error al guardar el permiso.", "guardarPermiso" + ex.getMessage());
        }
    }
    
    public Respuesta eliminarPermiso(Integer id){
        try{
            et = em.getTransaction();
            et.begin();
            Papelera model;
            if(id != null && id > 0){
                model = em.find(Papelera.class, id);
                if(model == null){
                    et.rollback();
                    return new Respuesta(false, "No se encontro el permiso a eliminar", "eliminarPermiso NoResultException");
                }
                em.remove(model);
            }else{
                et.rollback();
                return new Respuesta(false, "Debe cargar el permiso a eliminar.", "eliminarPermiso NoResultException");
            }
            et.commit();
            return new Respuesta(true, "", "");
        }catch(Exception ex){
            et.rollback();
            if (ex.getCause() != null && ex.getCause().getCause().getClass() == SQLIntegrityConstraintViolationException.class) {
                return new Respuesta(false, "No se puede eliminar el permiso porque tiene relaciones con otros registros.", "eliminarPermiso " + ex.getMessage());
            }
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al eliminar el permiso.", ex);
            return new Respuesta(false, "Ocurrio un error al eliminar el permiso.", "eliminarPermiso " + ex.getMessage());
        }
    }
    
    private List<PapeleraDto> convertirLista(List<Papelera> lista){
        List<PapeleraDto> retorno = new ArrayList<>();
        lista.forEach( (entity) -> {
            retorno.add(new PapeleraDto(entity));
        });
        return retorno;
    }
}
