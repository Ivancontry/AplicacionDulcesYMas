import { TerceroProveedor } from './tercero-proveedor';
import { CompraDetalle } from './compra-detalle';
export class Compra {
	constructor(
		public id?: number,
		public total?: number,
		public proveedor?: TerceroProveedor,
		public nitProveedor?: string,
		public fecha?: Date,
		public usuario?: string,
		public detalles?: CompraDetalle[]
	) { }
}
