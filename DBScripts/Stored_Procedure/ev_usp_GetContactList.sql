IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ev_usp_GetContactList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ev_usp_GetContactList] 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================    
-- Author		: Rajdeepsingh Khamare
-- Create date	: 11-Jun-2018
-- Description	: This procedure use to Get Contact List
-- Parameters	: NONE
-- Call			: EXEC [dbo].[ev_usp_GetContactList]    
-- =============================================================== 

CREATE PROCEDURE [dbo].[ev_usp_GetContactList]
AS
BEGIN
  SET NOCOUNT ON

  /* Declaration Block */
  DECLARE @varErrorMessage nvarchar(4000)
  DECLARE @varErrorSeverity int
  DECLARE @varErrorState int

  BEGIN TRY

    SELECT
      Id,
      FirstName,
      LastName,
      IsActive,
      Email,
      PhoneNumber
    FROM ev_tbl_Contacts
    WHERE IsDeleted = 0
  END
  TRY

  BEGIN CATCH
    SELECT
      @varErrorMessage = 'Error : ' + HOST_NAME() + ' : ' + OBJECT_NAME(@@PROCID) + ' : ' + ERROR_MESSAGE(),
      @varErrorSeverity = ERROR_SEVERITY(),
      @varErrorState = ERROR_STATE();

    RAISERROR (
    @varErrorMessage
    ,-- Message text.
    @varErrorSeverity
    ,-- Severity.
    @varErrorState -- State.
    );
  END CATCH

  SET NOCOUNT OFF
END