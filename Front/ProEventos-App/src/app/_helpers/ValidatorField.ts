import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidatorField {
    static mustMatch(controlName: string, matchingName: string): any {
        return (group: AbstractControl) => {
            const formGroup = group as FormGroup;
            const control = formGroup.controls[controlName];
            const matching = formGroup.controls[matchingName];

            if(matching.errors && !matching.errors['mustMatch']) {
                return null;
            }

            if(control.value !== matching.value) {
                matching.setErrors({mustMatch: true});
            } else {
                matching.setErrors(null);
            }

            return;
        }
    }
}
