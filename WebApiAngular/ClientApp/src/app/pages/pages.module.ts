import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../Shared/shared.module';
import { PAGE_ROUTES } from './pages.routes';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TerceroComponent } from './tercero/tercero.component';
import { ProductoDetallesComponent } from './producto-detalles/producto-detalles.component';
import { ListarProductosComponent } from './listar-productos/listar-productos.component';
import { NuevoProductoModalComponent } from '../components/nuevo-producto-modal/nuevo-producto-modal.component';
import { TerceroDetallesComponent } from './tercero/tercero-detalles/tercero-detalles.component';
import { ListarTercerosComponent } from '../components/listar-terceros/listar-terceros.component';
import { NuevoTerceroModalComponent } from '../components/nuevo-tercero-modal/nuevo-tercero-modal.component';



@NgModule({
	declarations: [DashboardComponent, TerceroComponent, ProductoDetallesComponent, ListarProductosComponent, NuevoProductoModalComponent, TerceroDetallesComponent, ListarTercerosComponent, NuevoTerceroModalComponent],
	exports: [
		DashboardComponent,
		TerceroComponent,
		ProductoDetallesComponent,
		NuevoProductoModalComponent
	],
	imports: [
		CommonModule,
		SharedModule,
		PAGE_ROUTES,
		FormsModule,
		ReactiveFormsModule
	],
	entryComponents: [NuevoProductoModalComponent]
})
export class PagesModule { }
