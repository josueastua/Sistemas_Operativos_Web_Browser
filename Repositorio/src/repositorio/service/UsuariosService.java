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
import javax.persistence.NonUniqueResultException;
import javax.persistence.Query;
import repositorio.modelo.Usuarios;
import repositorio.modelo.UsuariosDto;
import repositorio.util.EntityManagerHelper;
import repositorio.util.Respuesta;

/**
 *
 * @author IVAN
 */
public class UsuariosService {
    
    EntityManager em = EntityManagerHelper.getInstance().getManager();
    private EntityTransaction et;
    
    public Respuesta userLogin(String user, String pass){
        try{
            Query query = em.createNamedQuery("Usuarios.userLogin");
            query.setParameter("usuNombre", user);
            query.setParameter("usuPassword", pass);
            return new Respuesta(Boolean.TRUE, "", "", "Usuario", new UsuariosDto((Usuarios)query.getSingleResult()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No existe un usuario con esas credenciales.", "userLogin NoResultException");
        }catch(NonUniqueResultException ex){
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Existe mas de un usuario con esas credenciales.", ex);
            return new Respuesta(false, "Existe mas de un usuario con esas credenciales.", "userLogin " + ex.getMessage());
        }catch(Exception ex){
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al iniciar sesion.", ex);
            return new Respuesta(false, "Ocurrio un error al iniciar sesion.", "userLogin " + ex.getMessage());
        }
    }
    
    public Respuesta guardarUsuario(UsuariosDto user){
        try{
            et = em.getTransaction();
            et.begin();
            Usuarios ent;
            if(user.getUsuId() != null && user.getUsuId() > 0){
                ent = em.find(Usuarios.class, user.getUsuId());
                if(ent == null){
                    et.rollback();
                    return new Respuesta(false, "No se encontro el usuario a modificar", "guardarUsuario NoResultException");
                }
                ent.Actualizar(user);
                ent = em.merge(ent);
            }else{
                ent = new Usuarios(user);
                em.persist(ent);
            }
            et.commit();
            return new Respuesta(true, "", "", "Usuario", new UsuariosDto(ent));
        }catch(Exception ex){
            et.rollback();
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al guardar el usuario.", ex);
            return new Respuesta(false, "Ocurrio un error al guardar el usuario.", "guardarUsuario" + ex.getMessage());
        }
    }
    
    public Respuesta getUsuariosByName(String nombre){
        try{
            Query query = em.createNamedQuery("Usuarios.findByUsuNombre");
            query.setParameter("usuNombre", nombre);
            return new Respuesta(true, "", "", "Usuarios", convertirLista((List<Usuarios>)query.getResultList()));
        }catch(NoResultException ex){
            return new Respuesta(false, "No se encontraron coincidencias", "getUsuariosByName NoResultException");
        }catch(Exception ex){
            Logger.getLogger(UsuariosService.class.getName()).log(Level.SEVERE, "Ocurrio un error al obtener los usuarios.", ex);
            return new Respuesta(false, "Ocurrio un error al obtener los usuarios.", "getUsuariosByName " + ex.getMessage());
        }
    }
    
    private List<UsuariosDto> convertirLista(List<Usuarios> lista){
        List<UsuariosDto> retorno = new ArrayList<>();
        lista.forEach((entity) -> {
            retorno.add(new UsuariosDto(entity));
        });
        return retorno;
    }
}
