using System;
using System.Collections.Generic;

class Contract {
    public string Number { get; set; }
    public string Counterparty { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public bool IsExecuted { get; set; }
    public DateTime ExecutionDate { get; set; }
}

class ContractSystem {
    private List<Contract> contracts = new List<Contract>();

    public void AddContract(Contract contract) {
        contracts.Add(contract);
    }

    public void UpdateContract(Contract contract) {
        int index = contracts.FindIndex(c => c.Number == contract.Number);
        if (index != -1) {
            contracts[index] = contract;
        }
    }

    public void RemoveContract(string contractNumber) {
        contracts.RemoveAll(c => c.Number == contractNumber);
    }

    public List<Contract> GetContracts() {
        return contracts;
    }

    public List<Contract> GetExecutedContracts() {
        return contracts.FindAll(c => c.IsExecuted);
    }

    public List<Contract> GetNotExecutedContracts() {
        return contracts.FindAll(c => !c.IsExecuted);
    }

    public List<Contract> GetContractsByCounterparty(string counterparty) {
        return contracts.FindAll(c => c.Counterparty == counterparty);
    }

    public List<Contract> GetContractsByDateRange(DateTime startDate, DateTime endDate) {
        return contracts.FindAll(c => c.StartDate >= startDate && c.EndDate <= endDate);
    }

    public List<Contract> GetContractsByAmount(decimal minAmount, decimal maxAmount) {
        return contracts.FindAll(c => c.Amount >= minAmount && c.Amount <= maxAmount);
    }
}
