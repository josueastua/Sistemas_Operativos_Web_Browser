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
import repositorio.modelo.Permisos;
import repositorio.modelo.PermisosDto;
import repositorio.util.EntityManagerHelper;
import repositorio.util.Respuesta;

/**
 *
 * @author IVAN
 */
public class PermisosServices {
 
    EntityManager em = EntityManagerHelper.getInstance().getManager();
    private EntityTransaction et;
    
    public Respuesta getPermisosByUsuario(String usuid){//Los permisos que le han otorgado al usuario
        try{
            Query query = em.createNamedQuery("Permisos.findByPerUsuario", Permisos.class);
            query.setParameter("perUsuario", usuid);
            return new Respuesta(true, "", "", "Permisos", convertirLista((List<Permisos>)query.getResultList()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No se encontraron coincidencias", "getPermisosByUsuario NoResultException");
        }catch(Exception ex){
            Logger.getLogger(PermisosServices.class.getName()).log(Level.SEVERE, "Ocurrio un error al obtener los permisos.", ex);
            return new Respuesta(false, "Ocurrio un error al obtener los permisos.", "getPermisosByUsuario " + ex.getMessage());
        }
    }
    
    public Respuesta getPermisosByDueno(String usuDueno){//Los permisos que le han otorgado al usuario
        try{
            Query query = em.createNamedQuery("Permisos.findByPerDueno", Permisos.class);
            query.setParameter("perDueno", usuDueno);
            return new Respuesta(true, "", "", "Permisos", convertirLista((List<Permisos>)query.getResultList()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No se encontraron coincidencias", "getPermisosByDueno NoResultException");
        }catch(Exception ex){
            Logger.getLogger(PermisosServices.class.getName()).log(Level.SEVERE, "Ocurrio un error al obtener los permisos.", ex);
            return new Respuesta(false, "Ocurrio un error al obtener los permisos.", "getPermisosByDueno " + ex.getMessage());
        }
    }
    
    public Respuesta guardarPermiso(PermisosDto per){
        try{
            et = em.getTransaction();
            et.begin();
            Permisos ent;
            if(per.getPerId() != null && per.getPerId() > 0){
                ent = em.find(Permisos.class, per.getPerId());
                if(ent == null){
                    et.rollback();
                    return new Respuesta(false, "No se encontro el permiso a modificar", "guardarPermiso NoResultException");
                }
                ent.Actualizar(per);
                ent = em.merge(ent);
            }else{
                ent = new Permisos(per);
                em.persist(ent);
            }
            et.commit();
            return new Respuesta(true, "", "", "Usuario", new PermisosDto(ent));
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
            Permisos model;
            if(id != null && id > 0){
                model = em.find(Permisos.class, id);
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
    
    private List<PermisosDto> convertirLista(List<Permisos> lista){
        List<PermisosDto> retorno = new ArrayList<>();
        lista.forEach( (entity) -> {
            retorno.add(new PermisosDto(entity));
        });
        return retorno;
    }
}
