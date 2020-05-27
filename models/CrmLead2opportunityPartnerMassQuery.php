<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[CrmLead2opportunityPartnerMass]].
 *
 * @see CrmLead2opportunityPartnerMass
 */
class CrmLead2opportunityPartnerMassQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return CrmLead2opportunityPartnerMass[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return CrmLead2opportunityPartnerMass|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
