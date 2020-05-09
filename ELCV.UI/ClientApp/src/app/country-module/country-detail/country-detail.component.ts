import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country} from '../country';
import { CountryService } from '../country.service';
import { ConfirmDeleteModalComponent } from '../../shared/confirm-delete-modal/confirm-delete-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GenericRoutes } from '../../shared/generic-routes/generic-routes';
import { EMPTY } from 'rxjs';
@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.css']
})
export class CountryDetailComponent implements OnInit
{
  pageTitle = "";
  errorMessage = '';
  alertErrorMessage = { title: "", errorMessage:""}
  country: Country | undefined;
  recordDescription = "";
  routes = {};
  genericRoutes = new GenericRoutes();
  editRoute = "";
  listRoute = "";
  constructor(private route: ActivatedRoute, private router: Router, private countryService: CountryService, private _modalService: NgbModal) {
    
  }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');
    this.pageTitle = "Country Detail";
    if (param) {
      const id = +param;
      this.getCountry(id);
      this.routes = this.genericRoutes.getRoutesbyRouteName(this.router.config);
      this.editRoute = this.routes["countryEdit"].replace(":id", id);
      this.listRoute = this.routes['countryList'];
    }
     
  }

  getCountry(id: number) {
    this.countryService.getCountry(id).subscribe(data => {
      this.country = data
      this.recordDescription = "the country: " + this.country.countryName;
     
    }, error => {
        this.alertErrorMessage.title = "Error:";
        error.statusCode == "404" ?this.alertErrorMessage.errorMessage = "Country Not found"
          : this.alertErrorMessage.errorMessage = "Unexpected Error: Please contact your system administrator";
    });
  }

  onBack(): void {
    this.router.navigate([this.listRoute]);
  }

  onEdit(): void {
    this.router.navigate([this.editRoute]);
  }
  deleteCountry(id :number): void {
    this.countryService.delete(id).subscribe();
  }
  onDelete(id: number): void {
    const confirmDeleteModal = this._modalService.open(ConfirmDeleteModalComponent);
    confirmDeleteModal.componentInstance.modalData = { title: "Delete Country", recordName: this.recordDescription };
    confirmDeleteModal.result.then(
      (data: string) => {
        if (data === "delete") this.deleteCountry(id);
        this.router.navigate([this.listRoute]);
      },

    );
  }

}

 
  




  
