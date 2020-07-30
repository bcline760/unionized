/**
 * Represents a common data model for data items retrieved from the API
 */
export abstract class DataModel {
  constructor() {
    this.slug = null;
    this.createdAt = new Date();
    this.updatedAt = null;
    this.active = false;
  }

  /**
   * The unique identifying string of the data record
   */
  public slug: string | null;

  /**
   * When the record was created
   */
  public createdAt: Date;

  /**
   * When the record was updated
   */
  public updatedAt: Date | null;

  /**
   * When the record was last updated
   */
  public active: boolean;
}
