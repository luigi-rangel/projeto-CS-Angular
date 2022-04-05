import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/_helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  public form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.mustMatch('senha1', 'senha2')
    };

    this.form = this.fb.group({
      titulo: ['', Validators.required],
      pNome: ['', Validators.required],
      uNome: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      telefone: ['', Validators.required],
      funcao: ['', Validators.required],
      descricao: ['', Validators.required],
      senha1: ['', Validators.minLength(6)],
      senha2: ['']
    }, formOptions);
  }

  public resetForm(): void {
    this.form.reset();
  }

}
