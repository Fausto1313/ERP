<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ResPartnerCategory]].
 *
 * @see ResPartnerCategory
 */
class ResPartnerCategoryQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ResPartnerCategory[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ResPartnerCategory|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
