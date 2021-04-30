using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Layer
{
    public enum ErrorCodes
    {
        LoginFail,
        GetProduct,                  
        GetAllProductByUser,
        GetAllProductByCompany,
        SaveProduct,
        DeleteProduct,
        GetMenu,
        GetRol,
        GetRoles, 
        GetCompany,
        GetAllCompanysByUser,
        GetAllSpendingsByUser,
        GetAllSpendingsByCompany,
        SaveSpending
    }

    public enum ErrorValidations
    {
        UserInvalid,
        UserCompanysNull,
        GetProduct,
        GetAllProductByUser,
        GetAllProductByCompany,
        SaveProduct,
        DeleteProduct
    }

    public enum OKResponse
    {
        GetProduct,
        GetAllProductByUser,
        GetAllProductByCompany,
        SaveProduct,
        DeleteProduct,
        SaveSpending
    }

    public class Enums
    {
        public static Dictionary<ErrorCodes, string> ErrorsCodeMessage => new Dictionary<ErrorCodes, string>
        {
            { ErrorCodes.LoginFail, "Error al iniciar sesión" },
            { ErrorCodes.GetProduct, "Error al obtener producto" },
            { ErrorCodes.GetAllProductByUser, "Error al obtener productos por usuario" },
            { ErrorCodes.GetAllProductByCompany, "Error al obtener productos por empresa" },
            { ErrorCodes.SaveProduct, "Error al registrar producto" },
            { ErrorCodes.DeleteProduct, "Error al eliminar producto" },
            { ErrorCodes.GetMenu, "Error al obtener el menú" },
            { ErrorCodes.GetRol, "Error al obtener el rol del usuario" },
            { ErrorCodes.GetRoles, "Error al obtener listado de roles" },
            { ErrorCodes.GetCompany, "Error al obtener empresa" },
            { ErrorCodes.GetAllCompanysByUser, "Error al obtener listado de empresas" },
            { ErrorCodes.GetAllSpendingsByUser, "Error al obtener gastos por usuario" },
            { ErrorCodes.GetAllSpendingsByCompany, "Error al obtener gastos por empresa" },
            { ErrorCodes.SaveSpending, "Error al registrar gasto" }
        };

        public static Dictionary<ErrorValidations, string> ErrorsValidationMessage => new Dictionary<ErrorValidations, string>
        {
            { ErrorValidations.UserInvalid, "El usuario no existe o se encuentra bloqueado" },
            { ErrorValidations.UserCompanysNull, "El usuario no tiene sucursales activas" },
            { ErrorValidations.GetProduct, "Error al obtener producto" },
            { ErrorValidations.GetAllProductByUser, "Error al obtener productos por usuario" },
            { ErrorValidations.GetAllProductByCompany, "Error al obtener productos por empresa" },
            { ErrorValidations.SaveProduct, "Error al registrar producto" },
            { ErrorValidations.DeleteProduct, "Error al eliminar producto" }
        };

        public static Dictionary<OKResponse, string> OKResponseMessage => new Dictionary<OKResponse, string>
        {
            { OKResponse.GetProduct, "Producto encontrado con éxito" },
            { OKResponse.GetAllProductByUser, "Productos encontrados con éxito" },
            { OKResponse.GetAllProductByCompany, "Productos encontrados con éxito" },
            { OKResponse.SaveProduct, "Producto registrado correctamente" },
            { OKResponse.DeleteProduct, "Producto eliminado correctamente" },
            { OKResponse.SaveSpending, "Gasto registrado correctamente" }
        };
    }
}
