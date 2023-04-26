export interface FeedbackForm {
  id: number;
  technicalSkill: string;
  communication: string;
  roleCompetance: string;
  remarks: string;
  relevantExperience: number;
}

export interface RollOffForm {
  id: number;
  primarySkill: string;
  endDate: string;
  reason: string;
  otherReason: string;
  performanceIssue: boolean;
  resgined: boolean;
  underProbation: boolean;
  longLeave: boolean;
  leaveType: string;
}

export interface AssignedFrom {
  id: number;
  userDetailsId: number;
  employeeId: number;
  rollOffFormId: number;
  feedbackFormId: number;
  assignedTo: number;
}

export interface RollOffTransaction {
  rollOffForm: RollOffForm;
  feedbackForm: FeedbackForm;
  assignedFrom: AssignedFrom;
}