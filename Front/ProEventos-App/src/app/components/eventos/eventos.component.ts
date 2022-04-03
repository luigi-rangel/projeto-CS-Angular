import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../_models/Evento';
import { EventoService } from '../../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public widthImg = 150;
  public marginImg = 2;
  public isCollapsed = false;
  private _filtroLista = '';
  public message = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter((evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
  }

  constructor(private eventoService: EventoService, 
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

    public ngOnInit(): void {
    this.getEventos();
    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
    }, 5000);
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar eventos', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso!', 'Deletado!');
  }
 
  decline(): void {
    this.modalRef?.hide();
  }
}
