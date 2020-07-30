/**
 * Defines a response from the API
 * @typeParam T  The type of data expected to be returned from the API
 */
export class ApiResponse<T> {
  constructor() {
    this.data = null;
    this.message = null;
    this.success = false;
  }

  /**
  * The data returned from the API
  * @typeParam T  The type of data return from the API
  */
  public data: T | null;

  /**
   * Message returned back from the API
   */
  public message: string | null;

  /**
   * Indicates whether the API call is a success
   */
  public success: boolean
}
