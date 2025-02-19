import { Component } from "@angular/core";
import { Router, RouterLink } from "@angular/router";
import { AuthService } from "../../../services/auth-service";
import { LoginModel } from "../../../models/account/login-model";
import { InputErrorComponent } from '../../../components/input-error/input-error.component';
import { PopupErrorComponent } from '../../../components/popups/popup-error/popup-error.component';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
@Component({
  selector: 'app-login',
  imports: [
    InputErrorComponent,
    PopupErrorComponent,
    ReactiveFormsModule,
    FormsModule,
    RouterLink
  ],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  emailVisited: boolean = false;
  passwordVisited: boolean = false;
  loginError: string = '';
  errorMessageShow: boolean = false;
  logInDto: LoginModel = new LoginModel();
  logInForm: FormGroup = new FormGroup({
    Email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(64)]),
    Password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(128)])
  });

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.logInDto = this.logInForm.value as LoginModel;
    this.authService.performLogIn(this.logInDto).subscribe(
      token => {
        this.router.navigate(['']);
      },
      error => {
        if (error.status === 400) {
          this.loginError = 'Password or email is incorrect';
          this.errorMessageShow = true;
        } else {
          this.router.navigate(['/server-error']);
        }
      }
    );
  }

  errorShowFlagChange($event: boolean) {
    this.errorMessageShow = $event;
  }
}
