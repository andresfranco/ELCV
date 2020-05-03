import { EntityClassBase } from "../shared/EntityClassBase";

export class Country implements EntityClassBase
{
  id: number;
  createdByUser: string;
  createdDate: Date;
  modifiedByUser: string;
  modifiedDate: Date;
  countryCode: string;
  countryName: string;

}
