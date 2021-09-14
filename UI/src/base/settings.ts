/* eslint-disable camelcase */
import {REACT_APP_Host_API} from './environments'
export class Setting {
  static mainUrl:string = REACT_APP_Host_API;
  static getApiUrl = (address: string): string =>  Setting.mainUrl + address;
}
export default Setting;
