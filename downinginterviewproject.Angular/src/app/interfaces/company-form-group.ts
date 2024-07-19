import { FormControl } from "@angular/forms";

export interface CompanyFormGroup {
    name: FormControl<string>;
    code: FormControl<string>;
    sharePrice: FormControl<number | undefined>;
}
