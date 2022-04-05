import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/_helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.mustMatch('senha1', 'senha2')
    };

    this.form = this.fb.group({
      pNome: ['', [Validators.required, Validators.maxLength(20)]],
      uNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      user: ['', Validators.required],
      senha1: ['', Validators.required, Validators.minLength(6)],
      senha2: ['', Validators.required]
    }, formOptions);
  }

  public resetForm(): void {
    this.form.reset();
  }

}
