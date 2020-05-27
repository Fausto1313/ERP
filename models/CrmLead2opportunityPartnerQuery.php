<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmLead2opportunityPartner]].
 *
 * @see CrmLead2opportunityPartner
 */
class CrmLead2opportunityPartnerQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmLead2opportunityPartner[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmLead2opportunityPartner|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
