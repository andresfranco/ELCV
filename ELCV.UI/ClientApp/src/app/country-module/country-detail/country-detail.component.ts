import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country} from '../country';
import { CountryService } from '../country.service';
import { ConfirmDeleteModalComponent } from '../../shared/confirm-delete-modal/confirm-delete-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GenericRoutes } from '../../shared/generic-routes/generic-routes';
import { countryCrudLabels } from '../country-labels/country-labels';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.css']
})
export class CountryDetailComponent implements OnInit
{
  pageTitle = countryCrudLabels.detailTitlelabel;
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
    if (param) {
      const id = +param;
      this.getCountry(id);
      this.routes = this.genericRoutes.getRoutesbyRouteName(this.router.config);
      this.editRoute = this.routes["countryEdit"].replace(":id", id);
      this.listRoute = this.routes['countryList'];
    }
     
  }

  getCountry(id: number) {
    this.countryService.getCountry(id).subscribe((data:any) => {
      this.countryService.handleBackendJsonErrorResponse(data.StatusCode);
      this.country = data
      this.recordDescription = `${countryCrudLabels}:` + this.country.countryName;
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
    confirmDeleteModal.componentInstance.modalData = { title: countryCrudLabels.deleteTitleLabel, recordName: this.recordDescription };
    confirmDeleteModal.result.then(
      (data: string) => {
        if (data === "delete") this.deleteCountry(id);
        this.router.navigate([this.listRoute]);
      },

    );
  }

}

 
  




  
